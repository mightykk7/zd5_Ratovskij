﻿using System;
using System.Collections.Generic;
using System.Text;

namespace zd4_ratovskij
{
    public static class CreditCalculator
    {
        //вычисление ежемесячного платежа для аннуитетного платежа
        public static double CalculateAnnuityMonthlyPayment(double creditSum, int term, double percent)
        {
            if (percent == 0)
                return Math.Round(creditSum / term);

            double monthlyInterestRate = percent / 1200; //годовая процентная ставка в процентах

            /*формула коэффициента аннуитета
            K = (i × (1 + i)^n) / ((1 + i)^n — 1, где:
            i — месячная процентная ставка(годовая ставка, делённая на 12 месяцев);
            n — количество периодов(месяцев) погашения кредита.*/

            double numerator = monthlyInterestRate * Math.Pow(1 + monthlyInterestRate, term); //числитель
            double denominator = Math.Pow(1 + monthlyInterestRate, term) - 1; //знаменатель

            if (denominator == 0)
                return 0;

            double kf = numerator / denominator; //коэффициент аннуитета

            double monthlyPayment = creditSum * kf;
            return Math.Round(monthlyPayment, 2);

        }
        //вычисление общей суммы для аннуитетного платежа
        public static double CalculateAnnuityTotalSum(double monthlyPayment, int term)
        {
            return Math.Round(monthlyPayment * term, 2);
        }
        //вычисление переплаты для аннуитетного платежа
        public static double CalculateAnnuityOverpayment(double creditSum, double monthlyPayment, int term)
        {
            return Math.Round((monthlyPayment * term) - creditSum, 2);
        }
        // Расчет дифференцированного платежа (первый платеж)
        public static double CalculateDifferentiatedFirstPayment(double creditSum, int term, double percent)
        {
            double monthlyPrincipal = creditSum / term; // основная часть платежа
            double firstInterest = creditSum * (percent / 100) / 12; // проценты за первый месяц
            return Math.Round(monthlyPrincipal + firstInterest, 2);
        }
        // Расчет дифференцированного платежа (последний платеж)
        public static double CalculateDifferentiatedLastPayment(double creditSum, int term, double percent)
        {
            double monthlyPrincipal = creditSum / term; // основная часть платежа
            double lastInterest = monthlyPrincipal * (percent / 100) / 12; // проценты за последний месяц
            return Math.Round(monthlyPrincipal + lastInterest, 2);
        }
        // Расчет общей суммы для дифференцированного платежа
        public static double CalculateDifferentiatedTotalSum(double creditSum, int term, double percent)
        {
            double monthlyPrincipal = creditSum / term;
            double totalInterest = 0;

            for (int month = 0; month < term; month++)
            {
                double remainingSum = creditSum - (monthlyPrincipal * month);
                totalInterest += remainingSum * (percent / 100) / 12;
            }

            return Math.Round(creditSum + totalInterest, 2);
        }
        // Расчет переплаты для дифференцированного платежа
        public static double CalculateDifferentiatedOverpayment(double creditSum, double totalSum)
        {
            return Math.Round(totalSum - creditSum, 2);
        }
        //проверка корректности ввода суммы кредита
        public static void CheckValidCreditSum(double creditSum)
        {
            if (creditSum < 10000)
                throw new Exception("Минимальная сумма кредита 10 000 рублей");
            if (creditSum > 100000000)
                throw new Exception("Максимальная сумма кредита 100 000 000 рублей");
        }
        //проверка корректности ввода срока
        public static void CheckValidTerm(int term)
        {
            if (term < 1)
                throw new Exception("Минимальный срок 1 месяц");
            if (term > 360)
                throw new Exception("Максимальный срок 360 месяцев (30 лет)");
        }
    }
}
