﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MasterDetailTemplate.Models;
using MasterDetailTemplate.Views.RFID;

namespace MasterDetailTemplate.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.Browse, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Browse: // Not Use
                        MenuPages.Add(id, new NavigationPage(new ItemsPage()));
                        break;
                    case (int)MenuItemType.About: // HomePage
                        MenuPages.Add(id, new NavigationPage(new AboutPage()));
                        break;
                    case (int)MenuItemType.Test: // Test PoetryPage
                        MenuPages.Add(id, new NavigationPage(new TestPage()));
                        break;
                    case (int)MenuItemType.LoginAndLogout: // UserLoginPages
                        MenuPages.Add(id, new NavigationPage(new LoginAndLogoutPage()));
                        break;
                    case (int)MenuItemType.AquariumWaterSituation: // AquariumWaterSituationPage
                        MenuPages.Add(id, new NavigationPage(new AquariumWaterSituationPage()));
                        break;
                    case (int)MenuItemType.HistoricalRecordSearch: // HistoricalRecordSearchPage
                        MenuPages.Add(id, new NavigationPage(new HistoricalRecordSearchPage()));
                        break;
                    case (int)MenuItemType.BindAndEdit: // HistoricalRecordSearchPage
                        MenuPages.Add(id, new NavigationPage(new BindAndEditPage()));
                        break;
                    case (int)MenuItemType.NotifyRangeSet: // HistoricalRecordSearchPage
                        MenuPages.Add(id, new NavigationPage(new NotifyRangeSetPage()));
                        break;
                    case (int)MenuItemType.BluetoothConnect: // HistoricalRecordSearchPage
                        MenuPages.Add(id, new NavigationPage(new BluetoothConnectPage()));
                        break;
                    case (int)MenuItemType.RFIDReader: // HistoricalRecordSearchPage
                        MenuPages.Add(id, new NavigationPage(new RFIDReaderPage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}