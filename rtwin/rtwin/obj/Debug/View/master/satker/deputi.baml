   M S B A M L   `   `   `  ����@  <rtwin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:rtwin.View.master.satkerrtwin.View.master.satker  5      %    rtwin.View.master.satker.deputi   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:rtwin.View.master.satker     5      U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      .��5
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
btnAddData��5        GreenButton#���  6B   $��40��6h    � ToolTip$3 -MaterialDesignRaisedButton with Round Corners��6u   #��� ��6�   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��6�   $��5 5 0 0q�6'  .��5      �� 
�������$��Tambah Data��6/   5      5      �� 5   
   $��0��6   $ 
Horizontal=�6"   $��Right=�6;   $��0,0,20,0q�6W   .+�5       �� $��	0,15,20,0q�6   $��Center=�6+   $��Center=�6H    " MaterialDesignCaptionTextBlock#��[ 6c   Urutkan Berdasar5!      �� 5"      -   5         ��Name$ cmbSort��5"      $��Center=�6T   $��Center=�6q    & "MaterialDesignFloatingHintComboBox#��[ 6�   5%      �� 5&      -   5        $ btnSort��5&   '   $��10,5,0,0q�6     ButtonPagination#���  6O   $
��Left=�6z   .��5'      '  !MaterialDesignThemes.Wpf.PackIcon  -   5          Name$ 	arrowSort��5'   *   �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ ArrowUp=�6=   $��24��6L   $��24��6X   5(      5)      �� 5*   
   $��1��6   $ Vertical=�6"   $��Stretch=�6:   .+�5,      &   System.Windows.Controls.DataGrid  -   5          Name$ dgDeputi��5,      $��5 5 10 0q�6)   	   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 * 6;   
   CanUserAddRows
 .     
IsReadOnly .    Columns 5.      4  .System.Windows.Controls.DataGridTemplateColumn  5/      ,  &System.Windows.Controls.DataGridColumn   Header$
 Edit��6-   -   5        edit_header��   CellTemplate 50      �� 51      .R�52   "   �� $
 edit��6)   -   5        $
��Left=�52   J   $��30��6e   $��30��6q     
ButtonEdit#���  6|   $
 Edit��6�   .��53   &     $
 Edit=�6>   $��24��6J   $��24��6V   
�������6a   54   #   56      59        5:      $ Hapus��6-   -   5        hapus_header�� 5;      �� 5<      .R�5=   "   �� $ hapus��6)   -	   5        $
��Left=�5=   8   $��30��6g   $��30��6r     ButtonDelete#���  6~   $ Hapus��6�   .��5>   &     $ Delete=�6>   $��20��6L   $��20��6X   
�������6c   5?   #   5A      5D      5G      �� 5H      .+�5I      �  � ColumnDefinitions 5J      �� 5K      $��* �6+   67   �� 5L      $��* �6+   67   .+�5N      �� $��1��6!   $ 
Horizontal=�62   $��Right=�6K   $��	0,0,30,10q�6g   .+�5O      �� -
   5        $ 	firstPage��5O   !   $��0,0,15,0q�6L   #���  6^   $ Previus��6�   .��5P        $ 	FirstPage=�66   $��24��6G   $��24��6S   5Q      �� 5R      -   5        $ prevPage��5R   "   $��0,0,15,0q�6K   #���  6]   $ Previus��6�   .��5S        $ PagePrevious=�66   $��24��6J   $��24��6V   5T      �� 5U      $��Center=�6%   $��Center=�6B   $ 
Horizontal=�6]   .+�5W      �� .��6$   	Showing6-   �� 5X      -   5         ��Name$
 dari��5X   (   $��Center=�66   $��Center=�6S   #��[ 6o   215Y      �� 5Z      .��6$   To6(   �� 5[      -   5        $ sampai��5[   (   $��Center=�68   $��Center=�6U   #��[ 6q   215\      �� 5]      .��6$   of6(   �� 5^      -   5        $ total��5^   (   $��Center=�67   $��Center=�6T   #��[ 6p   215_      �� 5`      .��6$   	entries6-   5a      �� 5c      -   5        $ nextPage��5c   !   $��15,0,0,0q�6J   #���  6\   $
 Next��6�   .��5d        $ PageNext=�66   $��24��6F   $��24��6R   5e      �� 5f      -   5        $ lastPage��5f   !   $��15,0,0,0q�6J   #���  6\   $ 	Last Page��6�   .��5g        $ LastPage=�66   $��24��6F   $��24��6R   5h      5i      �� 5j      $��0��6!   $ 
Horizontal=�61   $
��Left=�6L   $��	10,0,0,10q�6g   .+�5k      �� $��Center=�6$   $��Center=�6A   #��[ 6\   Jumlah data5l      �� 5m      -   5        $ 
cmbJumData��5m   #   $��Center=�68   $��Center=�6U   $��	10,0,0,10q�6p   #��[ 6�   .@�5n      ��  �� 
IsSelected . .��6=   106A   �� 5o      .��6+   206/   �� 5p      .��6+   306/   5r      5s      5t      5u      5v      5y      5z      