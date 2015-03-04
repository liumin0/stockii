namespace Stockii
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::Stockii.SplashScreen1), true, false);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splashScreenManager2 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::Stockii.WaitForm1), true, true);
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.newGroupItem = new DevExpress.XtraBars.BarButtonItem();
            this.myGroupItem = new DevExpress.XtraBars.BarButtonItem();
            this.groupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.editGroupItem = new DevExpress.XtraBars.BarButtonItem();
            this.areaGroupItem = new DevExpress.XtraBars.BarButtonItem();
            this.areaMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.industryGroupItem = new DevExpress.XtraBars.BarButtonItem();
            this.industryMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.printItem = new DevExpress.XtraBars.BarButtonItem();
            this.dumpItem = new DevExpress.XtraBars.BarButtonItem();
            this.upBoardItem = new DevExpress.XtraBars.BarButtonItem();
            this.downBoardItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.skinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.hideContainerRight = new DevExpress.XtraBars.Docking.AutoHideContainer();
            this.combinePanel = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dockPanel5 = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer1 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dockPanel7_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dockPanel6_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.areaMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.industryMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.hideContainerRight.SuspendLayout();
            this.combinePanel.SuspendLayout();
            this.dockPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.newGroupItem,
            this.myGroupItem,
            this.editGroupItem,
            this.areaGroupItem,
            this.industryGroupItem,
            this.printItem,
            this.dumpItem,
            this.upBoardItem,
            this.downBoardItem,
            this.barButtonItem1,
            this.barButtonItem2,
            this.skinRibbonGalleryBarItem1});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 18;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2,
            this.ribbonPage3});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbon.Size = new System.Drawing.Size(1047, 147);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // newGroupItem
            // 
            this.newGroupItem.Caption = "新建分组";
            this.newGroupItem.Glyph = ((System.Drawing.Image)(resources.GetObject("newGroupItem.Glyph")));
            this.newGroupItem.Id = 1;
            this.newGroupItem.Name = "newGroupItem";
            this.newGroupItem.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.newGroupItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.newGroupItem_ItemClick);
            // 
            // myGroupItem
            // 
            this.myGroupItem.ActAsDropDown = true;
            this.myGroupItem.AllowDrawArrow = true;
            this.myGroupItem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.myGroupItem.Caption = "我的分组";
            this.myGroupItem.DropDownControl = this.groupMenu;
            this.myGroupItem.Glyph = ((System.Drawing.Image)(resources.GetObject("myGroupItem.Glyph")));
            this.myGroupItem.Id = 2;
            this.myGroupItem.Name = "myGroupItem";
            this.myGroupItem.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            // 
            // groupMenu
            // 
            this.groupMenu.Name = "groupMenu";
            this.groupMenu.Ribbon = this.ribbon;
            // 
            // editGroupItem
            // 
            this.editGroupItem.Caption = "编辑分组";
            this.editGroupItem.Glyph = ((System.Drawing.Image)(resources.GetObject("editGroupItem.Glyph")));
            this.editGroupItem.Id = 5;
            this.editGroupItem.Name = "editGroupItem";
            this.editGroupItem.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.editGroupItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.editGroupItem_ItemClick);
            // 
            // areaGroupItem
            // 
            this.areaGroupItem.ActAsDropDown = true;
            this.areaGroupItem.AllowDrawArrow = true;
            this.areaGroupItem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.areaGroupItem.Caption = "按地区";
            this.areaGroupItem.DropDownControl = this.areaMenu;
            this.areaGroupItem.Glyph = ((System.Drawing.Image)(resources.GetObject("areaGroupItem.Glyph")));
            this.areaGroupItem.Id = 7;
            this.areaGroupItem.Name = "areaGroupItem";
            this.areaGroupItem.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            // 
            // areaMenu
            // 
            this.areaMenu.Name = "areaMenu";
            this.areaMenu.Ribbon = this.ribbon;
            // 
            // industryGroupItem
            // 
            this.industryGroupItem.ActAsDropDown = true;
            this.industryGroupItem.AllowDrawArrow = true;
            this.industryGroupItem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.industryGroupItem.Caption = "按行业";
            this.industryGroupItem.DropDownControl = this.industryMenu;
            this.industryGroupItem.Glyph = ((System.Drawing.Image)(resources.GetObject("industryGroupItem.Glyph")));
            this.industryGroupItem.Id = 8;
            this.industryGroupItem.Name = "industryGroupItem";
            this.industryGroupItem.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            // 
            // industryMenu
            // 
            this.industryMenu.Name = "industryMenu";
            this.industryMenu.Ribbon = this.ribbon;
            // 
            // printItem
            // 
            this.printItem.Caption = "打印";
            this.printItem.Glyph = ((System.Drawing.Image)(resources.GetObject("printItem.Glyph")));
            this.printItem.Id = 9;
            this.printItem.Name = "printItem";
            this.printItem.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.printItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.printItem_ItemClick);
            // 
            // dumpItem
            // 
            this.dumpItem.Caption = "导出";
            this.dumpItem.Glyph = ((System.Drawing.Image)(resources.GetObject("dumpItem.Glyph")));
            this.dumpItem.Id = 10;
            this.dumpItem.Name = "dumpItem";
            this.dumpItem.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.dumpItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.dumpItem_ItemClick);
            // 
            // upBoardItem
            // 
            this.upBoardItem.Caption = "按向上";
            this.upBoardItem.Glyph = ((System.Drawing.Image)(resources.GetObject("upBoardItem.Glyph")));
            this.upBoardItem.Id = 11;
            this.upBoardItem.Name = "upBoardItem";
            this.upBoardItem.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            // 
            // downBoardItem
            // 
            this.downBoardItem.Caption = "按向下";
            this.downBoardItem.Glyph = ((System.Drawing.Image)(resources.GetObject("downBoardItem.Glyph")));
            this.downBoardItem.Id = 12;
            this.downBoardItem.Name = "downBoardItem";
            this.downBoardItem.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "N日和";
            this.barButtonItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.Glyph")));
            this.barButtonItem1.Id = 14;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "自定义计算";
            this.barButtonItem2.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.Glyph")));
            this.barButtonItem2.Id = 16;
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // skinRibbonGalleryBarItem1
            // 
            this.skinRibbonGalleryBarItem1.Caption = "skinRibbonGalleryBarItem1";
            this.skinRibbonGalleryBarItem1.Id = 17;
            this.skinRibbonGalleryBarItem1.Name = "skinRibbonGalleryBarItem1";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3,
            this.ribbonPageGroup4});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "分组";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.newGroupItem);
            this.ribbonPageGroup1.ItemLinks.Add(this.myGroupItem);
            this.ribbonPageGroup1.ItemLinks.Add(this.editGroupItem);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "自定义分组";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.areaGroupItem);
            this.ribbonPageGroup2.ItemLinks.Add(this.industryGroupItem);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "默认分组";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.printItem);
            this.ribbonPageGroup3.ItemLinks.Add(this.dumpItem);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "导出";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.upBoardItem);
            this.ribbonPageGroup4.ItemLinks.Add(this.downBoardItem);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "版块分区";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup5});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "指标";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup5.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.Text = "指标计算";
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup6});
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "皮肤";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.skinRibbonGalleryBarItem1);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 692);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1047, 31);
            // 
            // dockManager1
            // 
            this.dockManager1.AutoHideContainers.AddRange(new DevExpress.XtraBars.Docking.AutoHideContainer[] {
            this.hideContainerRight});
            this.dockManager1.AutoHideSpeed = 1000;
            this.dockManager1.DockingOptions.HideImmediatelyOnAutoHide = true;
            this.dockManager1.Form = this;
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane"});
            // 
            // hideContainerRight
            // 
            this.hideContainerRight.BackColor = System.Drawing.Color.White;
            this.hideContainerRight.Controls.Add(this.combinePanel);
            this.hideContainerRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.hideContainerRight.Location = new System.Drawing.Point(1027, 147);
            this.hideContainerRight.Name = "hideContainerRight";
            this.hideContainerRight.Size = new System.Drawing.Size(20, 545);
            // 
            // combinePanel
            // 
            this.combinePanel.Controls.Add(this.dockPanel2_Container);
            this.combinePanel.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.combinePanel.ID = new System.Guid("ce0705cd-e3f1-48f2-a868-ce15365efbfb");
            this.combinePanel.Location = new System.Drawing.Point(798, 147);
            this.combinePanel.Name = "combinePanel";
            this.combinePanel.Options.ShowCloseButton = false;
            this.combinePanel.OriginalSize = new System.Drawing.Size(200, 200);
            this.combinePanel.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.combinePanel.SavedIndex = 1;
            this.combinePanel.Size = new System.Drawing.Size(200, 397);
            this.combinePanel.Text = "拼接";
            this.combinePanel.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(192, 370);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // dockPanel5
            // 
            this.dockPanel5.Controls.Add(this.controlContainer1);
            this.dockPanel5.DockedAsTabbedDocument = true;
            this.dockPanel5.FloatLocation = new System.Drawing.Point(770, 487);
            this.dockPanel5.ID = new System.Guid("140df4ca-15f2-4eb8-a71a-ab8c940f6af4");
            this.dockPanel5.Name = "dockPanel5";
            this.dockPanel5.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel5.SavedIndex = 2;
            this.dockPanel5.SavedMdiDocument = true;
            this.dockPanel5.Text = "dockPanel3";
            // 
            // controlContainer1
            // 
            this.controlContainer1.Location = new System.Drawing.Point(0, 0);
            this.controlContainer1.Name = "controlContainer1";
            this.controlContainer1.Size = new System.Drawing.Size(612, 368);
            this.controlContainer1.TabIndex = 0;
            // 
            // dockPanel7_Container
            // 
            this.dockPanel7_Container.Location = new System.Drawing.Point(0, 0);
            this.dockPanel7_Container.Name = "dockPanel7_Container";
            this.dockPanel7_Container.Size = new System.Drawing.Size(200, 100);
            this.dockPanel7_Container.TabIndex = 0;
            // 
            // dockPanel6_Container
            // 
            this.dockPanel6_Container.Location = new System.Drawing.Point(0, 0);
            this.dockPanel6_Container.Name = "dockPanel6_Container";
            this.dockPanel6_Container.Size = new System.Drawing.Size(200, 100);
            this.dockPanel6_Container.TabIndex = 0;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageHeader;
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 147);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.Size = new System.Drawing.Size(1027, 545);
            this.xtraTabControl1.TabIndex = 6;
            this.xtraTabControl1.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtraTabControl1_SelectedPageChanged);
            this.xtraTabControl1.CloseButtonClick += new System.EventHandler(this.xtraTabControl1_CloseButtonClick);
            // 
            // MainForm
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.True;
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.BackColor2 = System.Drawing.Color.White;
            this.Appearance.BorderColor = System.Drawing.Color.White;
            this.Appearance.ForeColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseBorderColor = true;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 723);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.hideContainerRight);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "斯多克智能股票分析系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.areaMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.industryMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.hideContainerRight.ResumeLayout(false);
            this.combinePanel.ResumeLayout(false);
            this.dockPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem newGroupItem;
        private DevExpress.XtraBars.BarButtonItem myGroupItem;
        private DevExpress.XtraBars.BarButtonItem editGroupItem;
        private DevExpress.XtraBars.BarButtonItem areaGroupItem;
        private DevExpress.XtraBars.BarButtonItem industryGroupItem;
        private DevExpress.XtraBars.BarButtonItem printItem;
        private DevExpress.XtraBars.BarButtonItem dumpItem;
        private DevExpress.XtraBars.BarButtonItem upBoardItem;
        private DevExpress.XtraBars.BarButtonItem downBoardItem;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel combinePanel;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel7_Container;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel6_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel5;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer1;
        private DevExpress.XtraBars.Docking.AutoHideContainer hideContainerRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DevExpress.XtraBars.PopupMenu groupMenu;
        private DevExpress.XtraBars.PopupMenu areaMenu;
        private DevExpress.XtraBars.PopupMenu industryMenu;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager2;
    }
}