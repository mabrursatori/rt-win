   M S B A M L   `   `   `  ����@  <rtwin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:rtwin.View.master.lemburrtwin.View.master.lembur  5      0    *rtwin.View.master.lembur.FormFaktorPengali   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:rtwin.View.master.lembur     5      U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5
      �   � RowDefinitions  5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   5       � ColumnDefinitions 5   
   �� 5      $	��170 �6   6-   �� 5      $	��250 �6   6-   .+�5   
   �� $��5,10,0,0q�6    %  !MaterialDesignSubheadingTextBlock#��[  6&   $��0��6a   $��0��6n   Kode5      �� 5   
   -   5         ��Name$ txtKode��5      {�.  $��5q�65   $��0��6@   $��1��6M    % !MaterialDesignFloatingHintTextBox#��[ 6]   �� 5   
   $��5,10,0,0q�6   #��[  6&   $��1��6a   $��0��6n   Hari Lembur5      �� 5   
   -   5        $ txtHariLembur��5      {�.  $��5q�6;   $��1��6F   $��1��6S   #��[ 6c   �� 5   
   $��5,10,0,0q�6   #��[  6&   $��2��6a   $��0��6n   Faktor5       �� 5!   
   -   5        $ 	txtFaktor��5!      $��5q�6%   $��2��60   $��1��6=   #��[ 6M   6�   �� 5#   
   $��10q�6   $��3��6!   $��2��6.    �� Orientation$ 
Horizontal=�6C   $
��Left=�6\   .+�5$      �� -   5         ��Name$ btnsave��5$        GreenButton#���  6<   $��70��6b    � ToolTip$/ )Resource name: MaterialDesignRaisedButton��6m   .��6�   Save5&      �� 5'      -   5        $ btnClose��5'      $��10q�6'     MaterialDesignRaisedButton#��[ 6J   
���  ��
���  ��$��70��6�   $/ )Resource name: MaterialDesignRaisedButton��6�   .��6�   Close5)      �� 5*      -   5         ��Name$ 
lodongSave��5*   T   $��0,10,0,0q�6   $��1��6+   $ 
Horizontal=�6;   $y�Hidden=�6i   .+�5+      #  MaterialDesignThemes.Wpf.Card     UniformCornerRadius$ 14Q�6&   $��4q�6?   .��5,      �  % !MaterialDesignCircularProgressBar#��[ 6"    � Value$ 50Q�6]   	 � IsIndeterminate	 . 6h   5-      5/      50      52      53      