   M S B A M L   `   `   `  ����@  <rtwin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:rtwin.View.master.jabatanrtwin.View.master.jabatan  5      '    !rtwin.View.master.jabatan.jabatan   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:rtwin.View.master.jabatan     5      U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      .��5
      � $��0 0 0 20q�6     � RowDefinitions  5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   .+�5   
   �� -   5         ��Name$ 	rectangle��5      $��3��6'   $
��Left=�68   $	��Top=�6S      RectangleView#��[  6k   �� 5   
   $��0��6    �� Orientation$ 
Horizontal=�6"   $
��Left=�6;   .+�5      �� -   5         ��Name$ 
btnAddData��5      $��30��6C    � ToolTip$3 -MaterialDesignRaisedButton with Round Corners��6P   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��6�   $��12 5 0 0q�6�     GreenButton#��[ 6�   .��5      �� $��Tambah Data��6   5      5"      �� 5$   
   $��0��6   $ 
Horizontal=�6"   $��Right=�6;   $��0,0,20,0q�6W   .+�5&      �� $��
0,10,20,10q�6   $��Center=�6,   $��Center=�6I   Urutkan Berdasar5'      �� 5(      -   5         ��Name$ cmbSort��5(      $��Center=�6T   $��Center=�6q   5+      �� 5,      -   5        $ btnSort��5,   '   $��10,5,0,0q�6   $
��Left=�6O     ButtonPagination#���  6j   .��5-      '  !MaterialDesignThemes.Wpf.PackIcon  -   5          Name$ 	arrowSort��5-   *   �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ ArrowUp=�6=   $��24��6L   $��24��6X   5.      5/      �� 50   
   $��1��6   $ Vertical=�6"   $��Stretch=�6:   .+�52      &   System.Windows.Controls.DataGrid  -   5        	  Name$	 	dgJabatan��52      $��	10 8 10 0q�6*   
   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$
 * 6=      CanUserAddRows .     
IsReadOnly .    Columns 54      4  .System.Windows.Controls.DataGridTemplateColumn  55      ,  &System.Windows.Controls.DataGridColumn   Header$
 Edit��6-   -   5        edit_header��   CellTemplate 56      �� 57      .R�58   "   �� $
 edit��6)   -   5        $
��Left=�58   J   $��30��6e   $��30��6q    / +MaterialDesignFloatingActionMiniLightButton#��[ 6|   $
 Edit��6�   
��� � �
��� � �.��5:   &     $
 Edit=�6>   $��24��6J   $��24��6V   
�������6a   5;   #   5=      5@        5A      $ Hapus��6-   -	   5        hapus_header�� 5B      �� 5C      .R�5D   "   �� $ hapus��6)   -
   5        $
��Left=�5D   8   $��30��6g   $��30��6r   #��[ 6~   $ Hapus��6�   
���  ��
���  ��.��5F   &     $ Delete=�6>   $��20��6L   $��20��6X   
�������6c   5G   #   5I      5L      5O      �� 5P      .+�5Q      �  � ColumnDefinitions 5R      �� 5S      $��* �6+   67   �� 5T      $��* �6+   67   .+�5W      �� $��1��6!   $ 
Horizontal=�62   $��Right=�6K   $��	0,0,30,10q�6g   .+�5X      �� -   5        $ 	firstPage��5X   !   $��0,0,15,0q�6L   $ Previus��6^   #���  6p   .��5Y        $ 	FirstPage=�66   $��24��6G   $��24��6S   5Z      �� 5[      -   5        $ prevPage��5[   "   $��0,0,15,0q�6K   $ Previus��6]   #���  6o   .��5\        $ PagePrevious=�66   $��24��6J   $��24��6V   5]      �� 5^      $��Center=�6%   $��Center=�6B   $ 
Horizontal=�6]   .+�5`      �� .��6$   	Showing6-   �� 5a      -   5         ��Name$
 dari��5a   (   $��Center=�66   $��Center=�6S   215b      �� 5c      .��6$   To6(   �� 5d      -   5        $ sampai��5d   (   $��Center=�68   $��Center=�6U   215e      �� 5f      .��6$   of6(   �� 5g      -   5        $ total��5g   (   $��Center=�67   $��Center=�6T   215h      �� 5i      .��6$   	entries6-   5j      �� 5l      -   5        $ nextPage��5l   !   $��15,0,0,0q�6J   $
 Next��6\   #���  6k   .��5m        $ PageNext=�66   $��24��6F   $��24��6R   5n      �� 5o      -   5        $ lastPage��5o   !   $��15,0,0,0q�6J   $ 	Last Page��6]   #���  6q   .��5p        $ LastPage=�66   $��24��6F   $��24��6R   5q      5r      �� 5s      $��0��6!   $ 
Horizontal=�61   $
��Left=�6L   $��	10,0,0,10q�6g   .+�5t      �� $��Center=�6$   $��Bottom=�6A   $��	0,15,0,17q�6\   
���   �Jumlah data5u      �� 5v      -   5        $ 
cmbJumData��5v   #   $��Center=�68   $��Center=�6U   $��10,4,0,6q�6p   .@�5w      ��  �� 
IsSelected . .��6=   106A   �� 5x      .��6+   206/   �� 5y      .��6+   306/   5{      5|      5}      5~      5      5�      5�      