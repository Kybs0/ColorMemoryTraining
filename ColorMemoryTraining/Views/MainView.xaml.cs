﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using ColorMemoryTraining.Business.Excel;
using ColorMemoryTraining.Views.Models;
using Path = System.Windows.Shapes.Path;

namespace ColorMemoryTraining.Views
{
    /// <summary>
    /// MainView.xaml 的交互逻辑
    /// </summary>
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();
        }
        private void StartButton_OnClick(object sender, RoutedEventArgs e)
        {
            StartTrainingButton.Visibility = Visibility.Collapsed;
            UserProfileView.Visibility = Visibility.Visible;
        }

        public static readonly DependencyProperty UserInfoProperty = DependencyProperty.Register(
            "UserInfo", typeof(UserInfoMode), typeof(MainView), new PropertyMetadata(default(UserInfoMode)));

        public UserInfoMode UserInfo
        {
            get { return (UserInfoMode)GetValue(UserInfoProperty); }
            set { SetValue(UserInfoProperty, value); }
        }
        private void EditUserProfileView_OnUserInfoInputed(object sender, UserInfoMode userInfoMode)
        {
            UserInfo = userInfoMode;
            userInfoMode.StartRecord();
            _userDetailTestRecord.UserInfo = userInfoMode;
            //MemoryPicturesExcelHelper.SaveMemoryTestData(_userDetailTestRecord);
            UserProfileView.Visibility = Visibility.Collapsed;
            UserIntroductionView.Visibility = Visibility.Visible;
        }
        private UserDetailTestRecordInfo _userDetailTestRecord = new UserDetailTestRecordInfo();

        private void UserIntroductionView_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MemoryTrainingView.UserDetailTestRecord = _userDetailTestRecord;
            UserIntroductionView.Visibility = Visibility.Collapsed;
            UserStartingGrid.Visibility = Visibility.Collapsed;
        }

        private void MemoryTrainingView_OnTestingCompleted(object sender, EventArgs e)
        {
            MessageBox.Show(Window.GetWindow(this), "测试结束，谢谢！");
            UserStartingGrid.Visibility = Visibility.Visible;
            StartTrainingButton.Visibility = Visibility.Visible;

            //MemoryPicturesExcelHelper.SaveMemoryTestData(_userDetailTestRecord);
        }
    }
}
