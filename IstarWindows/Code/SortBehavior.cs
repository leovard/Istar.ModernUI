﻿using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;

namespace IstarWindows.Code
{
    public class SortBehavior
    {
        public static readonly DependencyProperty CanUserSortColumnsProperty =
            DependencyProperty.RegisterAttached(
                "CanUserSortColumns",
                typeof(bool),
                typeof(SortBehavior),
                new FrameworkPropertyMetadata(OnCanUserSortColumnsChanged));

        public static readonly DependencyProperty CanUseSortProperty =
            DependencyProperty.RegisterAttached(
                "CanUseSort",
                typeof(bool),
                typeof(SortBehavior),
                new FrameworkPropertyMetadata(true));

        public static readonly DependencyProperty SortDirectionProperty =
            DependencyProperty.RegisterAttached(
                "SortDirection",
                typeof(ListSortDirection?),
                typeof(SortBehavior));

        public static readonly DependencyProperty SortExpressionProperty =
            DependencyProperty.RegisterAttached(
                "SortExpression",
                typeof(string),
                typeof(SortBehavior));

        [AttachedPropertyBrowsableForType(typeof(ListView))]
        public static bool GetCanUserSortColumns(ListView element)
        {
            return (bool)element.GetValue(CanUserSortColumnsProperty);
        }

        [AttachedPropertyBrowsableForType(typeof(ListView))]
        public static void SetCanUserSortColumns(ListView element, bool value)
        {
            element.SetValue(CanUserSortColumnsProperty, value);
        }

        [AttachedPropertyBrowsableForType(typeof(GridViewColumn))]
        public static bool GetCanUseSort(GridViewColumn element)
        {
            if (element == null)
            {
                return false;
            }
            return (bool)element.GetValue(CanUseSortProperty);
        }

        [AttachedPropertyBrowsableForType(typeof(GridViewColumn))]
        public static void SetCanUseSort(GridViewColumn element, bool value)
        {
            element.SetValue(CanUseSortProperty, value);
        }

        [AttachedPropertyBrowsableForType(typeof(GridViewColumn))]
        public static ListSortDirection? GetSortDirection(GridViewColumn element)
        {
            return (ListSortDirection?)element.GetValue(SortDirectionProperty);
        }

        [AttachedPropertyBrowsableForType(typeof(GridViewColumn))]
        public static void SetSortDirection(GridViewColumn element, ListSortDirection? value)
        {
            element.SetValue(SortDirectionProperty, value);
        }

        [AttachedPropertyBrowsableForType(typeof(GridViewColumn))]
        public static string GetSortExpression(GridViewColumn element)
        {
            return (string)element.GetValue(SortExpressionProperty);
        }

        [AttachedPropertyBrowsableForType(typeof(GridViewColumn))]
        public static void SetSortExpression(GridViewColumn element, string value)
        {
            element.SetValue(SortExpressionProperty, value);
        }

        private static void OnCanUserSortColumnsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var listView = (ListView)d;
            if ((bool)e.NewValue)
            {
                listView.AddHandler(ButtonBase.ClickEvent, (RoutedEventHandler)OnColumnHeaderClick);
                if (listView.IsLoaded)
                {
                    DoInitialSort(listView);
                }
                else
                {
                    listView.Loaded += OnLoaded;
                }
            }
            else
            {
                listView.RemoveHandler(ButtonBase.ClickEvent, (RoutedEventHandler)OnColumnHeaderClick);
            }
        }

        private static void OnLoaded(object sender, RoutedEventArgs e)
        {
            var listView = (ListView)e.Source;
            listView.Loaded -= OnLoaded;
            DoInitialSort(listView);
        }

        private static void DoInitialSort(ListView listView)
        {
            var gridView = (GridView)listView.View;
            var column = gridView.Columns.FirstOrDefault(c => GetSortDirection(c) != null);
            if (column != null)
            {
                DoSort(listView, column);
            }
        }

        private static void OnColumnHeaderClick(object sender, RoutedEventArgs e)
        {
            var columnHeader = e.OriginalSource as GridViewColumnHeader;
            if (columnHeader != null && GetCanUseSort(columnHeader.Column))
            {
                DoSort((ListView)e.Source, columnHeader.Column);
            }
        }

        private static void DoSort(ListView listView, GridViewColumn newColumn)
        {
            var sortDescriptions = listView.Items.SortDescriptions;
            var newDirection = ListSortDirection.Ascending;

            var propertyPath = ResolveSortExpression(newColumn);
            if (propertyPath == null) return;
            if (sortDescriptions.Count > 0)
            {
                if (sortDescriptions[0].PropertyName == propertyPath)
                {
                    newDirection = GetSortDirection(newColumn) == ListSortDirection.Ascending ?
                        ListSortDirection.Descending :
                        ListSortDirection.Ascending;
                }
                else
                {
                    var gridView = (GridView)listView.View;
                    foreach (var column in gridView.Columns.Where(c => GetSortDirection(c) != null))
                    {
                        SetSortDirection(column, null);
                    }
                }

                sortDescriptions.Clear();
            }

            sortDescriptions.Add(new SortDescription(propertyPath, newDirection));
            SetSortDirection(newColumn, newDirection);
        }

        private static string ResolveSortExpression(GridViewColumn column)
        {
            var propertyPath = GetSortExpression(column);
            if (propertyPath != null) return propertyPath;
            var binding = (Binding)column.DisplayMemberBinding;
            return binding?.Path.Path;
        }
    }
}