   M S B A M L   `   `   `  ����@  <rtwin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:rtwin.View.master.ijinrtwin.View.master.ijin  5      &     rtwin.View.master.ijin.FormLeave   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:rtwin.View.master.ijin     5      U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5
      � .+�5   
   �� $
��Left=�6   $	��Top=�6/   $
��1050��6G   $	��523��6T      RectangleView#��[  6a   �� 5   
   -   5          ��Name$  gbTitel��5      $$��Tambah Data Waktu Kerja Detail��6$     MaterialDesignGroupBox#���  6L   $��16q�6}   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth3=�6�   $��0q�6�   .  (MaterialDesignThemes.Wpf.ColorZoneAssist   Mode$
 Dark=�6�   .��5      �� -   5         ��Name$
 svGb��5   A   $��Visible=�6   $	��Top=�6O   $	��450��6g   .��5   
   �  � RowDefinitions 5      �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      $
��auto �6    60    � ColumnDefinitions 5       �� 5!      $	��160 �6#   61   �� 5"      $	��200 �6#   61   .+�5&      �� $��5,10,0,0q�6    % !MaterialDesignSubheadingTextBlock#��[ 6*   $��0��6e   $��0��6r   	Kode Ijin5'      �� 5(      -   5         ��Name$ txtKodeIjin��5(      $��5q�6+   $��0��66   $��1��6C    % !MaterialDesignFloatingHintTextBox#��[ 6S   �� 5*      $��5,10,0,0q�6   #��[ 6*   $��1��6e   $��0��6r   
Jenis Ijin5+      �� 5,      -   5        $ 
txtKetIjin��5,      $��5q�6*   $��1��65   $��1��6B   #��[ 6R   �� 5.      $��5,10,0,0q�6   #��[ 6*   $��2��6e   $��0��6r   Perhitungan5/      �� 50      -   5         ��Name$ cmbPerhitungan��50      $��5q�6/   $��2��6:   $��1��6G    �� SelectedValuePath$ Content��6W   6u   �� 52      $��5,10,0,0q�6   #��[ 6*   $��3��6e   $��0��6r   	Ketentuan53      �� 54      -   5        $ cmbKetentuan��54      $��5q�6-   $��3��68   $��1��6E   $ Content��6U   6s   �� 56      $��5,10,0,0q�6   #��[ 6*   $��4��6e   $��0��6r   Jatah57      �� 58      -   5        $ txtjatah��58      $��5q�6(   $��4��63   $��1��6@   #��[ 6P   �� 5:      $��5,10,0,0q�6   #��[ 6*   $��5��6e   $��0��6r   
Ket Kredit5;      �� 5<      -   5        $ cmbKetKredit��5<      $��5q�6-   $��5��68   $��1��6E   $ Content��6U   6s   �� 5>      $��5,10,0,0q�6   #��[ 6*   $��6��6e   $��0��6r   Berlaku (bln)5?      �� 5@      -	   5        $ 
txtBerlaku��5@      $��5q�6*   $��6��65   $��1��6B   #��[ 6R   �� 5B      $��5,10,0,0q�6   #��[ 6*   $��7��6e   $��0��6r   	Ket Dasar5C      �� 5D      -
   5        $ cmbKetDasar��5D      $��5q�6,   $��7��67   $��1��6D   $ Content��6T   6r   �� 5F      $��5,10,0,0q�6   #��[ 6*   $��8��6e   $��0��6r   Berlaku Diawal5G      �� 5H      -   5        $ cmbBerlakuDiawal��5H      $��5q�61   $��8��6<   $��1��6I   $ Content��6Y   6w   �� 5J      $��5,10,0,0q�6   #��[ 6*   $��9��6e   $��0��6r   
Keterangan5K      �� 5L      -   5        $ cmbKodeTidakHadir��5L      $��5q�62   $��9��6=   $��1��6J   $ Content��6Z   6x   �� 5N      $��5,10,0,0q�6   #��[ 6*   $��10��6e   $��0��6s   Perhitungan Hari Kerja5O      d� 5P      -   5        	 d�Name$	 chkHitungHariKerja��5P   _   $
��Left=�6   $��5q�66   $��10��6A   $��1��6O    * &MaterialDesignSwitchAccentToggleButton#��[ 6{   
 � ToolTip$,
 &MaterialDesignSwitchAccentToggleButton��6�    d� 	IsChecked$
 TrueY�6�   �� 5R      $��5,10,0,0q�6   #��[ 6*   $��11��6e   $��0��6s   Perhitungan Jam Kerja5S      d� 5T      -   5        $	 chkPerhitunganJamKerja��5T   _   $
��Left=�6   $��5q�66   $��11��6A   $��1��6O   #��[ 6   $,
 &MaterialDesignSwitchAccentToggleButton��6�   $
 TrueY�6�   �� 5V      $��5,10,0,0q�6   #��[ 6*   $��12��6e   $��0��6s   
Potongan5W      �� 5X      -   5        $ txtPotongan��5X      $��5q�6+   $��12��66   $��1��6D   #��[ 6T   �� 5Z      $��10q�6   $��13��6%   $��2��63    �� Orientation$ 
Horizontal=�6H   $
��Left=�6a   .+�5[      �� -   5         ��Name$ btnsave��5[        GreenButton#���  6@   $��70��6f   $/
 )Resource name: MaterialDesignRaisedButton��6q   .��6�   Save5]      �� 5^      -   5        $ btnClose��5^      $��10q�6+     MaterialDesignRaisedButton#��[ 6N   
���  ��
���  ��$��70��6�   $/
 )Resource name: MaterialDesignRaisedButton��6�   .��6�   Close5`      �� 5a      -   5         ��Name$ 
lodongSave��5a   X   $��0,10,0,0q�6   $��1��6/   $ 
Horizontal=�6?   $y�Hidden=�6m   .+�5b      #  MaterialDesignThemes.Wpf.Card     UniformCornerRadius$ 14Q�6*   $��4q�6C   .��5c      �  % !MaterialDesignCircularProgressBar#��[ 6&    � Value$ 50Q�6a    � IsIndeterminate . 6l   5d      5f      5g      5h      5i      5j      5k      5m      