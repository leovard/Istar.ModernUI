using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows;
using Istar.ModernUI.Windows.Controls;
using IstarWindows.Models;
using SpeechLib;

namespace IstarWindows.Code
{
    public class SpeechConverter
    {
        public static SpVoice Voice { get; set; } = new SpVoice();
        private static readonly ModernWindow MainWin = (ModernWindow)Application.Current.MainWindow;

        /// <summary>
        /// Озвучивание выбранного события на СЕГОДНЯ и ЗАВТРА в TodayJobListBox при условии включенного звука.
        /// </summary>
        /// <param name="job">Вызывается событием TodayJobListBox.SelectionChanged в Jobs.xaml.vb</param>
        /// <remarks></remarks>
        [STAThread]
        public static void GetJobVoice(string job)
        {
            Thread.Sleep(10);
            if (MainWin.TitleLinks.FirstOrDefault(l => l.Source == new Uri("cmd://GoSound", UriKind.Absolute))?
                .DisplayName != "Выключить звук" || job == null)
                return;
            if (Voice != null)
            {
                Voice.Pause();
                Voice = null;
            }
            Voice = new SpVoice();
            Voice.Speak(job, (SpeechVoiceSpeakFlags)65);
        }
        /// <summary>
        /// Озвучивание суммы выставленного счета в OrderListView при условии включенного звука.
        /// </summary>
        /// <param name="order">Вызывается событием OrderListView.SelectionChanged в Orders/G5.xaml.vb</param>
        /// <remarks></remarks>
        [STAThread]
        public static void GetVoice(Order order)
        {
            Thread.Sleep(10);
            if (order == null)
            {
                return;
            }
            if (order.Paidtotal == 0)
            {
                order.Paidtotal = Convert.ToDecimal("0,00");
            }
            if (order.Paidtotal.ToString(CultureInfo.InvariantCulture).Length < 2)
            {
                order.Paidtotal = Convert.ToDecimal(order.Paidtotal + ",00");
            }
            var paidTotal = order.Paidtotal.ToString(CultureInfo.CurrentCulture).Split(',');
            if (paidTotal[1].Length < 2)
            {
                paidTotal[1] = paidTotal[1][0].ToString() + 0;
            }
            paidTotal[1] = (paidTotal[1][0].ToString() + paidTotal[1][1]);
            string roubls;
            string kops;
            if (paidTotal[0].EndsWith("1") && !(paidTotal[0].EndsWith("11")))
            {
                roubls = "рубль";
            }
            else if (paidTotal[0].EndsWith("2") && !(paidTotal[0].EndsWith("12")) || paidTotal[0].EndsWith("3") && !(paidTotal[0].EndsWith("13")) || paidTotal[0].EndsWith("4") && !(paidTotal[0].EndsWith("14")))
            {
                roubls = "рубля";
            }
            else
            {
                roubls = "рублей";
            }
            if (paidTotal[1] == 0.ToString())
            {
                paidTotal[1] = "";
                kops = "";
            }
            else if (paidTotal[1].EndsWith("1") && !(paidTotal[1].EndsWith("11")))
            {
                kops = "копейка";
            }
            else if (paidTotal[1].EndsWith("2") && !(paidTotal[1].EndsWith("12")) || paidTotal[1].EndsWith("3") && !(paidTotal[1].EndsWith("13")) || paidTotal[1].EndsWith("4") && !(paidTotal[1].EndsWith("14")))
            {
                kops = "копейки";
            }
            else
            {
                kops = "копеек";
            }
            double i;
            var kopsFirst = new[] { "01", "02", "03", "04", "05", "06", "07", "08", "09", "21", "22", "31", "32", "41", "42", "51", "52", "61", "62", "71", "72", "81", "82", "91", "92" };
            var kopsSecond = new[] { "одна", "две", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять", "двадцать одна", "двадцать две", "тридцать одна", "тридцать две", "сорок одна", "сорок две", "пятьдесят одна", "пятьдесят две", "шестьдесят одна", "шестьдесят две", "семьдесят одна", "семьдесят две", "восемьдесят одна", "восемьдесят две", "девяносто одна", "девяносто две" };
            for (i = 0; i < kopsFirst.GetLength(0); i++)
            {
                paidTotal[1] = paidTotal[1].Replace(kopsFirst.ToString(), kopsSecond.ToString());
            }
            if (Voice != null)
            {
                Voice.Pause();
                Voice = null;
            }
            Voice = new SpVoice();
            if (order.Paidtotal > 0)
            {
                Voice.Speak("Счет оплачен на сумму " + paidTotal[0] + " " + roubls + " " + paidTotal[1] + " " + kops, (SpeechVoiceSpeakFlags) 65);
            }
            else
            {
                Voice.Speak("Счет не оплачен.", (SpeechVoiceSpeakFlags) 65);
            }
        }
    }
}