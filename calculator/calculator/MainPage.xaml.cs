﻿using System.Collections.Generic;
using System;
using Xamarin.Forms;


namespace calculator
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();

        
        }

        private decimal firstNumber;
        private String operatorName;
        private bool isOperatorClicked;

        private void BtnCommon_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (LblResult.Text == "0" || isOperatorClicked) {

                isOperatorClicked = false;
                LblResult.Text = button.Text;
            }
            else
            {
                LblResult.Text = button.Text;
            }
        }

        private void BtnClear_Clicked(object sender, EventArgs e) {

            LblResult.Text = "0";
            isOperatorClicked = false;
            firstNumber = 0;
        
        }

        private void BtnX_Clicked(object sender, EventArgs e)
        {

            String number = LblResult.Text;
            if (number != "0") {
            
                number = number.Remove(number.Length - 1,1);

                if (String.IsNullOrEmpty(number))
                {
                    LblResult.Text = "0";

                }
                else
                {
                    LblResult.Text =  number;
                }


            }
        }

        public async void BtnCommonOperation_Clicked(object sender,EventArgs e)
        {
            var button = sender as Button;
            isOperatorClicked = true;
            operatorName = button.Text;
            firstNumber = Convert.ToDecimal(LblResult.Text);
        }

        public async void BtnPercentage_Clicked(object sender, EventArgs e)
        {
            try
            {
                String number = LblResult.Text;
                if (number != "0")
                {
                    decimal percentValue = Convert.ToDecimal(number);
                    String result = (percentValue / 100).ToString("0.##");
                    LblResult.Text = result;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private void BtnEqual_Clicked(object sender, EventArgs e) {

            try
            {
                decimal secondNumber = Convert.ToDecimal(LblResult.Text);
                String finalResult = Calculate(firstNumber,secondNumber).ToString("0.##");
                LblResult.Text = finalResult;   
            }
            catch(Exception ex)
            {
                DisplayAlert("Error",ex.Message, "OK");     
            }

        }

        public decimal Calculate(decimal firstNumber, decimal secondNumber)
        {
            decimal result = 0;
            if (operatorName == "+")
            {
                result = firstNumber + secondNumber;
            }
            else if(operatorName == "-") 
            {
                result = firstNumber - secondNumber;
            }
            else if (operatorName == "*")
            {
                result = firstNumber * secondNumber;
            }
            else if (operatorName == "/")
            {
                result = firstNumber / secondNumber;
            }
            return result;
        }



    }
}
