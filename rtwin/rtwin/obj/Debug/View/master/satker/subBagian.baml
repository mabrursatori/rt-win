   M S B A M L   `   `   `  ����@  <rtwin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:rtwin.View.master.satkerrtwin.View.master.satker  5      (    "rtwin.View.master.satker.subBagian   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:rtwin.View.master.satker     5      U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      .��5
      �   � RowDefinitions  5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   .+�5   
   �� $��3��6   $
��Left=�6%   $	��Top=�6@   $
��1050��6X   $	��523��6e      RectangleView#��[  6r   �� 5   
   $��0��6    �� Orientation$ 
Horizontal=�6"   $
��Left=�6;   .+�5      �� -   5         ��Name$ 
btnAddData��5        GreenButton#���  6B   $��40��6h    � ToolTip$3 -MaterialDesignRaisedButton with Round Corners��6u   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��6�   $��5 5 0 0q�6�   .��5      �� $��Tambah Data��6   5      �� 5      -   5        $ 	btnSearch��5   '   $��10,5,0,0q�6     ButtonPagination#���  6R   $
��Left=�6}   .��5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ Search=�6*   $��24��68   $��24��6D   5      5      �� 5   
   $��0��6   $��Center=�6"   $��Center=�6?   .+�5       )  #MaterialDesignThemes.Wpf.DialogHost  -   5          Name$ dialog��5    (   $	��Top=�5!         DialogContent 5"      � 5#        5$      �� 5%      $��* �6,   69   �� 5&      $��70 �6,   6:   .+�5(      �� $��0��6%   $	��300��62   $ Vertical=�6>   $��0,0,0,0q�6U   $��Center=�6g   $
��Left=�6�   .+�5)      �� -   5         ��Name$ cmbKodeDeputi��5)   �   $��
10,10,10,0q�6'   )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 Deputi��6j   $	��250��6�    & "MaterialDesignFloatingHintComboBox#��[ 6�   5+      �� 5,      -   5        $ cmbKodeBiro��5,   �   $��
10,10,10,0q�6'   $
	 Biro��6<   $	��250��6�   #��[ 6�   5.      �� 5/      -   5        $ cmbKodebagian��5/   p   $��
10,10,10,0q�6'   $	 Bagian��6<   $	��250��6d   #��[ 6�   51      �� 53         MaterialDesignLightSeparator#��[ 6(   54      �� 55      $��1��6%   $ 
Horizontal=�62   $��Right=�6K   $��20q�6g   .+�56      �� -   5        $ btnTampilkan��56   %    $  MaterialDesignRaisedAccentButton#��[ 57      $	��100��58      $5 /Resource name: MaterialDesignRaisedAccentButton��59      .��6?   	Tampilkan5;      5<      5>      5@      5A      �� 5B   
   $��0��6   $ 
Horizontal=�6"   $��Right=�6;   $��0,0,20,0q�6W   .+�5D      �� $��	0,15,20,0q�6   $��Center=�6+   $��Center=�6H    " MaterialDesignCaptionTextBlock#��[ 6c   Urutkan Berdasar5E      �� 5F      -   5        $ cmbSort��5F      $��Center=�6T   $��Center=�6q   #��[ 6�   5I      �� 5J      -	   5        $ btnSort��5J   '   $��10,5,0,0q�6   #���  6O   $
��Left=�6z   .��5K        -
   5        
  Name$
 	arrowSort��5K   *   $ ArrowUp=�6=   $��24��6L   $��24��6X   5L      5M      �� 5N   
   $��1��6   $ Vertical=�6"   $��Stretch=�6:   .+�5P      &   System.Windows.Controls.DataGrid  -   5          Name$ dgSubBagian��5P      $��5 5 10 0q�6,      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6>      CanUserAddRows .     
IsReadOnly .    Columns 5R      4  .System.Windows.Controls.DataGridTemplateColumn  5S      ,	  &System.Windows.Controls.DataGridColumn 	  Header$
 Edit��6-   -   5        edit_header��   CellTemplate 5T      �� 5U      .R�5V   "   �� $
 edit��6)   -   5        $
��Left=�5V   J   $��30��6e   $��30��6q     
ButtonEdit#���  6|   $
 Edit��6�   .��5W   &     $
 Edit=�6>   $��24��6J   $��24��6V   
�������6a   5X   #   5Z      5]        5^      $ Hapus��6-   -   5        hapus_header�� 5_      �� 5`      .R�5a   "   �� $ hapus��6)   -   5        $
��Left=�5a   8   $��30��6g   $��30��6r     ButtonDelete#���  6~   $ Hapus��6�   .��5b   &     $ Delete=�6>   $��20��6L   $��20��6X   
�������6c   5c   #   5e      5h      5k      �� 5l      .+�5m      �  � ColumnDefinitions 5n      �� 5o      $��* �6+   67   �� 5p      $��* �6+   67   .+�5r      �� $��1��6!   $ 
Horizontal=�62   $��Right=�6K   $��	0,0,30,10q�6g   .+�5s      �� -   5        $ 	firstPage��5s   !   $��0,0,15,0q�6L   #���  6^   $ Previus��6�   .��5t        $ 	FirstPage=�66   $��24��6G   $��24��6S   5u      �� 5v      -   5        $ prevPage��5v   "   $��0,0,15,0q�6K   #���  6]   $ Previus��6�   .��5w        $ PagePrevious=�66   $��24��6J   $��24��6V   5x      �� 5y      $��Center=�6%   $��Center=�6B   $ 
Horizontal=�6]   .+�5{      �� .��6$   	Showing6-   �� 5|      -   5         ��Name$
 dari��5|   (   $��Center=�66   $��Center=�6S   #��[ 6o   215}      �� 5~      .��6$   To6(   �� 5      -   5        $ sampai��5   (   $��Center=�68   $��Center=�6U   #��[ 6q   215�      �� 5�      .��6$   of6(   �� 5�      -   5        $ total��5�   (   $��Center=�67   $��Center=�6T   #��[ 6p   215�      �� 5�      .��6$   	entries6-   5�      �� 5�      -   5        $ nextPage��5�   !   $��15,0,0,0q�6J   #���  6\   $
 Next��6�   .��5�        $ PageNext=�66   $��24��6F   $��24��6R   5�      �� 5�      -   5        $ lastPage��5�   !   $��15,0,0,0q�6J   #���  6\   $ 	Last Page��6�   .��5�        $ LastPage=�66   $��24��6F   $��24��6R   5�      5�      �� 5�      $��0��6!   $ 
Horizontal=�61   $
��Left=�6L   $��	10,0,0,10q�6g   .+�5�      �� $��Center=�6$   $��Center=�6A   #��[ 6\   Jumlah data5�      �� 5�      -   5        $ 
cmbJumData��5�   #   $��Center=�68   $��Center=�6U   $��	10,0,0,10q�6p   #��[ 6�   .@�5�      ��  �� 
IsSelected . .��6=   106A   �� 5�      .��6+   206/   �� 5�      .��6+   306/   5�      5�      5�      5�      5�      5�      5�      