   M S B A M L   `   `   `  ����@  <rtwin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:rtwin.View.master.lemburrtwin.View.master.lembur  5      1    +rtwin.View.master.lembur.FormLemburOtomatis   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:rtwin.View.master.lembur     5      U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5
      �   � RowDefinitions  5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,    � ColumnDefinitions 5   
   �� 5      $	��170 �6   6-   �� 5      $	��250 �6   6-   .+�5   
   �� $��5,10,0,0q�6    %  !MaterialDesignSubheadingTextBlock#��[  6&   $��0��6a   $��0��6n   Kode5      �� 5   
   -   5         ��Name$ txtKode��5      {�.  $��5q�65   $��0��6@   $��1��6M    % !MaterialDesignFloatingHintTextBox#��[ 6]   �� 5   
   $��5,10,0,0q�6   #��[  6&   $��1��6a   $��0��6n   Nama Satker5      �� 5   
   -   5        $ txtNamaSatker��5      {�.  $��5q�6;   $��1��6F   $��1��6S   #��[ 6c   �� 5    
   $��5,10,0,0q�6   #��[  6&   $��2��6a   $��0��6n   Lembur Otomatis5!      d� 5"   
   -   5         d�Name$ chkLemburOtomatis��5"   Z   $
��Left=�6   $��5q�62   $��2��6=   $��1��6J    * &MaterialDesignSwitchAccentToggleButton#��[ 6u    � ToolTip$, &MaterialDesignSwitchAccentToggleButton��6�    d� 	IsChecked$
 TrueY�6�   �� 5$   
   $��5,10,0,0q�6   #��[  6&   $��3��6a   $��0��6n   Lembur Otomatis5%      d� 5&   
   -   5        $ chkLemburLibur��5&   Z   $
��Left=�6   $��5q�62   $��3��6=   $��1��6J   #��[ 6r   $, &MaterialDesignSwitchAccentToggleButton��6�   $
 TrueY�6�   �� 5(   
   $��5,10,0,0q�6   #��[  6&   $��4��6a   $��0��6n   Perhitungan5)      �� 5*   
   -   5         ��Name$ cmbPerhitungan��5*       �� SelectedValuePath$ Content��6+   $��5q�6G   $��4��6R   $��1��6_   �� 5,   
   $��10q�6   $��5��6!   $��2��6.    �� Orientation$ 
Horizontal=�6C   $
��Left=�6\   .+�5-      �� -   5        	 ��Name$	 btnsave��5-        GreenButton#���  6<   $��70��6b   $/ )Resource name: MaterialDesignRaisedButton��6m   .��6�   Save5/      �� 50      -   5        $	 btnClose��50      $��10q�6'     MaterialDesignRaisedButton#��[ 6J   
���  ��
���  ��$��70��6�   $/ )Resource name: MaterialDesignRaisedButton��6�   .��6�   Close52      �� 53      -   5        
 ��Name$
 
lodongSave��53   T   $��0,10,0,0q�6   $��1��6+   $ 
Horizontal=�6;   $y�Hidden=�6i   .+�54      #  MaterialDesignThemes.Wpf.Card     UniformCornerRadius$ 14Q�6&   $��4q�6?   .��55      �  % !MaterialDesignCircularProgressBar#��[ 6"    � Value$ 50Q�6]    � IsIndeterminate . 6h   56      58      59      5;      5<      