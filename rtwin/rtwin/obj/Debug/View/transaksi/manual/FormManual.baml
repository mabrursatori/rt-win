   M S B A M L   `   `   `  ����@  <rtwin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:rtwin.View.transaksi.manualrtwin.View.transaksi.manual  5      1clr-namespace:rtwin.ViewModelrtwin.ViewModel  5
      S OMaterialDesignExtensions, Version=2.7.0.0, Culture=neutral, PublicKeyToken=nullwQclr-namespace:MaterialDesignExtensions.Controls;assembly=MaterialDesignExtensions!MaterialDesignExtensions.Controls 5      {Sclr-namespace:MaterialDesignExtensions.Converters;assembly=MaterialDesignExtensions#MaterialDesignExtensions.Converters 5       WPFToolkit.ExtendeddEclr-namespace:Xceed.Wpf.Toolkit.Obselete;assembly=WPFToolkit.ExtendedXceed.Wpf.Toolkit.Obselete 5      ,    &rtwin.View.transaksi.manual.FormManual   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:rtwin.View.transaksi.manual     5      U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -	viewModelclr-namespace:rtwin.ViewModel  5
      `controlsQclr-namespace:MaterialDesignExtensions.Controls;assembly=MaterialDesignExtensions  5      d
convertersSclr-namespace:MaterialDesignExtensions.Converters;assembly=MaterialDesignExtensions  5      OosbEclr-namespace:Xceed.Wpf.Toolkit.Obselete;assembly=WPFToolkit.Extended  5      X	 TXceed.Wpf.Toolkit, Version=3.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit 	 5        � 	Resources  5      C  =MaterialDesignExtensions.Converters.NullToVisibilityConverter   notNullToVisibleConverter   	NullValue   NotNullValue��%@   &	          5   
   $ 	Collapsed=�6Q   $ Visible=�6g   5      .��5      � .+�5   
   �� $
��Left=�6   $	��Top=�6/   $
��1050��6G   $	��523��6T     RectangleView#��[ 6a   �� 5   
   -   5         ��Name$ gbTitel��5      $��Tambah Data Libur��6$     MaterialDesignGroupBox#���  6?   $��16q�6p   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth3=�6|   .  (MaterialDesignThemes.Wpf.ColorZoneAssist   Mode$
 Dark=�6�   $��0q�6�   .��5      �  � RowDefinitions 5      �� 5      $
��auto �6$   64   �� 5      $
��auto �6$   64   �� 5      $
��auto �6$   64   �� 5      $
��auto �6$   64   �� 5      $
��auto �6$   64    � ColumnDefinitions 5      �� 5       $	��120 �6'   65   �� 5!      $	��390 �6'   65   .+�5#      �� $��0��6   $��10q�6)      MaterialDesignBody2TextBlock#��[ 66   $
��auto��6l   $��0��6y   $��Center=�6�   Nip6�   �� 5$      -   5         ��Name$ svNip��5$   -   $��0��6    $��Stretch=�6<   $��Stretch=�6Z   $��16q�6v   $
��Auto=�5%      $
��Auto=�6<   $��1��6_   .��5&      �� $��Center=�6!   $
��auto��6>   	 �� Orientation$	 Vertical=�6K   .+�5'      :  4MaterialDesignExtensions.Controls.TextBoxSuggestions  
   TextBoxSuggestionsSource
 66   ��  �� Path$ TextBoxSuggestionsSource�   TextBox. 5(      �� -   5         ��Name$ txtNip��5(   M   $	��290��6&   $
��Left=�62   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Masukan Nama Atau Nip��6]    % !MaterialDesignFloatingHintTextBox#��[ 6�   ��6�   �� $
 Text� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5)      5+      5,      �� 5-      -   5         ��Name$ lblNip��5-      $
��Left=�6,   $y�Hidden=�6G   $��0��6[   $��	50,30,0,0q�6h   #��[ 6|   $
��auto��6�   $��1��6�   6�   �� 5.      $��1��6   $��10q�6)   #��[ 66   $	��100��6l   $��0��6x   $��Center=�6�   Tanggal Masuk6�   (  "System.Windows.Controls.DatePicker  5/      -   5          Name$ tglMasuk��5/   D   $	��150��6   $
��Left=�6)   $��1��6V   $��50,0,0,0q�6c   $��1��6u   6�   �� 51      $��2��6   $��0��6)   $��	10,20,0,0q�69   #��[ 6L   	Jam Masuk6�   % 	 Xceed.Wpf.Toolkit.MaskedTextBox  52      -   5          Name$ txtJamMasuk��52   �   $��50,0,0,0q�6%   $
��Left=�67      Mask$ 00:00��6R   $��30��6_   #��[ 6j   $��2��6�   $��1��6�   6�   �� 54      $��3��6   $��0��6)   $��	10,30,0,0q�69   #��[ 6L   
Jam Keluar6�   �� 55      $��3��6   $��1��6*   $��50,0,0,0q�6:   $	 
horizontal=�6L   $��Center=�6e   .+�56        -   5        $ txtJamKeluar��56   �   $ 00:00��6)   $��30��66   $
��Left=�6A   #��[ 6\   6�   �� 57      -   5         ��Name$ panelGantiHAri��57   h   $
��Left=�6!   $	 
Horizontal=�6<   $��	20,20,0,0q�6U   .+�58      d� -	   5         d�Name$ chkGantiHari��58   �    * &MaterialDesignSwitchAccentToggleButton#��[ 6(    � ToolTip$, &MaterialDesignSwitchAccentToggleButton��6h    d� 	IsChecked$ FalseY�6�   �� 59      .��6    
Ganti Hari6-   5:      5<      �� 5?      $��4��6   $��2��6*   $	 
Horizontal=�6>   .+�5@      �� -
   5         ��Name$ btnsave��5@        GreenButton#��[ 6D   $��70��6i   .��6u   Save5B      �� 5C      -   5        $ btnClose��5C      $��10q�6/     MaterialDesignRaisedButton#��[ 6R   
���  ��
���  ��$��70��6�   .��6�   Close5E      �� 5F      -   5        $ 
lodongSave��5F   L   $��0,10,0,0q�6!   $	 
Horizontal=�63   $y�Hidden=�6a   .+�5G      #  MaterialDesignThemes.Wpf.Card     UniformCornerRadius$ 14Q�6.   $��4q�6G   .��5H      �  % !MaterialDesignCircularProgressBar#��[ 6*    � Value$ 50Q�6e    � IsIndeterminate . 6p   5I      5K      5L      5M      5N      5O      5P      