   M S B A M L   `   `   `  ����@  <rtwin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:rtwin.View.master.timecardrtwin.View.master.timecard  5      0    *rtwin.View.master.timecard.timecard_detail   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:rtwin.View.master.timecard     5      U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      .��5
      �   � RowDefinitions  5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   .+�5   
   �� $��3��6    �� RadiusX$ 20��6%   $
��Left=�62   $	��Top=�6M    �� RadiusY$ 20��6e   $
��1050��6r   $	��523��6      RectangleView#��[  6�   �� 5   
   $��0��6    �� Orientation$ 
Horizontal=�6"   $
��Left=�6;   .+�5      �� -   5         ��Name$ 
btnAddData��5        GreenButton#���  6B   $��40��6h    � ToolTip$3 -MaterialDesignRaisedButton with Round Corners��6u   #��� ��6�   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��6�   $��5 5 0 0q�6'  .��5      �� 
�������$��Tambah Data��6/   5      �� 5      -   5        $ 	btnSearch��5   '   $��10,5,0,0q�6     ButtonPagination#���  6R   $
��Left=�6}   .��5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ Search=�6*   $��24��68   $��24��6D   5      5       �� 5!   
   $��0��6   $��Center=�6"   $��Center=�6?   .+�5"      )  #MaterialDesignThemes.Wpf.DialogHost  -   5          Name$ dialog��5"   (   $	��Top=�5#      	   DialogContent	 5$      � 5%        5&      �� 5'      $��* �6,   69   �� 5(      $��70 �6,   6:   .+�5*      �� $��0��6%   $	��300��62   $ Vertical=�6>   $��0,0,0,0q�6U   $��Center=�6g   $
��Left=�6�   .+�5+      �� -   5        
 ��Name$
 cmbKodeRange��5+   t   $��
10,10,10,0q�6'   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Kode Range��6<   $	��250��6h    & "MaterialDesignFloatingHintComboBox#��[ 6�   5-      �� 5.      -   5        $
 	cmbSatker��5.   x   $��
10,10,10,0q�6'   $ Nama Departemen��6;   $	��250��6l   #��[ 6�   50      �� 51         MaterialDesignLightSeparator#��[ 6(   52      �� 53      $��1��6%   $ 
Horizontal=�62   $��Right=�6K   $��20q�6g   .+�54      �� -   5        $ btnTampilkan��54   %    $  MaterialDesignRaisedAccentButton#��[ 55      $	��100��56      $5 /Resource name: MaterialDesignRaisedAccentButton��57      .��6?   	Tampilkan59      5:      5<      5>      5?      �� 5@   
   $��0��6   $ 
Horizontal=�6"   $��Right=�6;   $��0,0,20,0q�6W   .+�5B      �� $��	0,15,20,0q�6   $��Center=�6+   $��Center=�6H    " MaterialDesignCaptionTextBlock#��[ 6c   Urutkan Berdasar5C      �� 5D      -   5        $
 cmbSort��5D      $��Center=�6T   $��Center=�6q   #��[ 6�   5G      �� 5H      -   5        $ btnSort��5H   '   $��10,5,0,0q�6   #���  6O   $
��Left=�6z   .��5I        -	   5          Name$ 	arrowSort��5I   *   $ ArrowUp=�6=   $��24��6L   $��24��6X   5J      5K      �� 5L   
   $��1��6   $ Vertical=�6"   $��Stretch=�6:   .+�5N      &   System.Windows.Controls.DataGrid  -
   5          Name$ dgTimeCardDetail��5N      $��5 5 10 0q�61      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6C      CanUserAddRows .     
IsReadOnly .    Columns 5P      4  .System.Windows.Controls.DataGridTemplateColumn  5Q      ,	  &System.Windows.Controls.DataGridColumn 	  Header$
 Edit��6-   -   5        edit_header��   CellTemplate 5R      �� 5S      .R�5T   "   �� $
 edit��6)   -   5        $
��Left=�5T   J   $��30��6e   $��30��6q     
ButtonEdit#���  6|   $
 Edit��6�   
�������.��5V   &     $
 Edit=�6>   $��24��6J   $��24��6V   5W   #   5Y      5\        5]      $ Hapus��6-   -   5        hapus_header�� 5^      �� 5_      .R�5`   "   �� $ hapus��6)   -   5        $
��Left=�5`   8   $��30��6g   $��30��6r     ButtonDelete#���  6~   $ Hapus��6�   
�������.��5b   &     $ Delete=�6>   $��20��6L   $��20��6X   5c   #   5e      5h      5k      �� 5l      .+�5m      �  � ColumnDefinitions 5n      �� 5o      $��* �6+   67   �� 5p      $��* �6+   67   .+�5r      �� $��1��6!   $ 
Horizontal=�62   $��Right=�6K   $��	0,5,30,10q�6g   .+�5s      �� -   5        $ 	firstPage��5s   !   $��0,0,15,0q�6L   #���  6^   $ Previus��6�   .��5t        $ 	FirstPage=�66   $��24��6G   $��24��6S   5u      �� 5v      -   5        $ prevPage��5v   "   $��0,0,15,0q�6K   #���  6]   $ Previus��6�   .��5w        $ PagePrevious=�66   $��24��6J   $��24��6V   5x      �� 5y      $��Center=�6%   $��Center=�6B   $ 
Horizontal=�6]   .+�5{      �� .��6$   	Showing6-   �� 5|      -   5         ��Name$
 dari��5|   (   $��Center=�66   $��Center=�6S   #��[ 6o   215}      �� 5~      .��6$   To6(   �� 5      -   5        $ sampai��5   (   $��Center=�68   $��Center=�6U   #��[ 6q   215�      �� 5�      .��6$   of6(   �� 5�      -   5        $ total��5�   (   $��Center=�67   $��Center=�6T   #��[ 6p   215�      �� 5�      .��6$   	entries6-   5�      �� 5�      -   5        $ nextPage��5�   !   $��15,0,0,0q�6J   #���  6\   $
 Next��6�   .��5�        $ PageNext=�66   $��24��6F   $��24��6R   5�      �� 5�      -   5        $ lastPage��5�   !   $��15,0,0,0q�6J   #���  6\   $ 	Last Page��6�   .��5�        $ LastPage=�66   $��24��6F   $��24��6R   5�      5�      �� 5�      $��0��6!   $ 
Horizontal=�61   $
��Left=�6L   $��	10,0,0,10q�6g   .+�5�      �� $��Center=�6$   $��Center=�6A   #��[ 6\   Jumlah data5�      �� 5�      -   5        $
 
cmbJumData��5�   #   $��Center=�68   $��Center=�6U   $��	10,0,0,10q�6p   #��[ 6�   .@�5�      ��  �� 
IsSelected . .��6=   106A   �� 5�      .��6+   206/   �� 5�      .��6+   306/   5�      5�      5�      5�      5�      5�      5�      