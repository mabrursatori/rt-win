   M S B A M L   `   `   `  ����@  <rtwin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:rtwin.View.master.lemburrtwin.View.master.lembur  5      .    (rtwin.View.master.lembur.parameterLembur   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:rtwin.View.master.lembur     5      U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      X TXceed.Wpf.Toolkit, Version=3.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5
      .��5      �   � RowDefinitions  5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,    � ColumnDefinitions 5   
   �� 5      $	��290 �6   6-   �� 5      $	��350 �6   6-   .+�5   
   �� $��5,10,0,0q�6    %  !MaterialDesignSubheadingTextBlock#��[  6&   $��0��6a   $��0��6n   Jam Minimum Lembur5      %  Xceed.Wpf.Toolkit.MaskedTextBox  5   
   -   5          Name$ jamMinimumLembur��5   :   $��0��6   $��1��6*   $��5q�6T      Mask$ 00:00��6_    % !MaterialDesignFloatingHintTextBox#��[ 6l   .��6�   5      �� 5!   
   $��5,10,0,0q�6   #��[  6&   $��1��6a   $��0��6n   Jam Maksimum Lembur5"        5#   
   -   5        $ jamMaksimumLembur��5#   :   $��1��6   $��1��6*   $��5q�6U   $ 00:00��6`   #��[ 6m   .��6�   5$      �� 5&   
   $��5,10,0,0q�6   #��[  6&   $��2��6a   $��0��6n   Jam Minimum Lembur Hari Libur5'        5(   
   -   5        $ jamMinimumLemburHariLibur��5(   :   $��2��6   $��1��6*   $��5q�6]   $ 00:00��6h   #��[ 6u   .��6�   5)      �� 5+   
   $��5,10,0,0q�6   #��[  6&   $��3��6a   $��0��6n    Jam Maksimal Lembur Hari Libur5,        5-   
   -   5        $  jamMaksimalLemburHariLibur��5-   :   $��3��6   $��1��6*   $��5q�6^   $ 00:00��6i   #��[ 6v   .��6�   5.      �� 50   
   $��5,10,0,0q�6   #��[  6&   $��4��6a   $��0��6n   Jumlah Maksimum Total Lembur51      �� 52   
   -   5         ��Name$ jumMaksimumTotalLembur��52   /   $��4��6   $��1��6   $��5q�6O   #��[ 6�   .��6�   53      �� 55   
   $��5,10,0,0q�6   #��[  6&   $��5��6a   $��0��6n   #!Jumlah Maksimum Terima Uang Makan56      �� 57   
   -   5        $  jumMaksimumTerimaUangMakan��57   /   $��5��6   $��1��6   $��5q�6S   #��[ 6_   .��6�   58      �� 5:   
   $��5,10,0,0q�6   #��[  6&   $��6��6a   $��0��6n   Tarif Uang Makan Lembur5;      �� 5<   
   -   5        $ tarifUangMakanLembur��5<   /   $��6��6   $��1��6   $��5q�6M   #��[ 6Y   .��6�   5=      �� 5?   
   $��10q�6   $��7��6!   $��2��6.    �� Orientation$ 
Horizontal=�6C   $
��Left=�6\   .+�5@      �� -   5         ��Name$ btnsave��5@        GreenButton#���  6<   $��70��6b    � ToolTip$/ )Resource name: MaterialDesignRaisedButton��6m   .��6�   Save5B      �� 5D      -	   5         ��Name$ 
lodongSave��5D   T   $��0,10,0,0q�6   $��1��6+   $ 
Horizontal=�6;   $y�Hidden=�6i   .+�5E      #  MaterialDesignThemes.Wpf.Card  	   UniformCornerRadius$	 14Q�6&   $��4q�6?   .��5F      �  % !MaterialDesignCircularProgressBar#��[ 6"   
 � Value$
 50Q�6]    � IsIndeterminate . 6h   5G      5I      5J      5L      5M      