   M S B A M L   `   `   `  ����@  <rtwin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:rtwin.View.master.shiftrtwin.View.master.shift  5      )    #rtwin.View.master.shift.shiftHarian   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:rtwin.View.master.shift     5      U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      .��5      �   � RowDefinitions  5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   .+�5   
   �� 5      �� 5   
   $��0��6    �� Orientation$ 
Horizontal=�6"   $
��Left=�6;   .+�5      � $	��134��6   .+�5      �� -   5         ��Name$ 
btnAddData��5      $��40��6F    � ToolTip$3 -MaterialDesignRaisedButton with Round Corners��6S   #��� ��6�   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��6�   $��5 0 0 0q�6     GreenButton#���   6  .��5      �� 
�������$��Tambah Data��63   5       5!      5"      �� 5#   
   $��0��6   $ 
Horizontal=�6"   $��Right=�6;   $��0,0,20,0q�6W   .+�5$      �� $��	0,10,20,0q�6   $��Center=�6+   $��Center=�6H    " MaterialDesignCaptionTextBlock#��[ 6c   Urutkan Berdasar5%      �� 5&      -   5         ��Name$ cmbSort��5&      $��Center=�6T   $��Center=�6q    & "MaterialDesignFloatingHintComboBox#��[ 6�   5)      �� 5*      -   5        $ btnSort��5*   +   $��10,0,0,0q�6     ButtonPagination#���  6S   $
��Left=�6~   .��5+      '  !MaterialDesignThemes.Wpf.PackIcon  -   5          Name$ 	arrowSort��5+   *   �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ ArrowUp=�6=   $��24��6L   $��24��6X   5,      5-      �� 5.   
   $��1��6   .+�5/      �� .��50      &   System.Windows.Controls.DataGrid  -   5          Name$ dgShiftHarian��50      	   FrozenColumnCount$	 5��6.   $��	10 5 10 0q�6D   
   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$
 * 6W   $	��370��6g      CanUserAddRows .     
IsReadOnly .    Columns 52      4  .System.Windows.Controls.DataGridTemplateColumn  53      ,  &System.Windows.Controls.DataGridColumn   Header$ Detail��6-      CellTemplate 54      �� 55      .R�56   "   �� $ detail��6)   -   5        $
��Left=�56   9   $��30��6g   $��30��6s    / +MaterialDesignFloatingActionMiniLightButton#��[ 6~   
��� ���
��� ���$ Detail��6�   .��57   &     $ Details=�6>   
���   �$��24��6`   $��24��6l   58   #   5:      5=        5>      $ Hapus��6-   -   5        hapus_header�� 5?      �� 5@      .R�5A   "   �� $ hapus��6)   -   5        $
��Left=�5A   8   $��30��6g   $��30��6r   #��[ 6~   
���  ��
���  ��$ Hapus��6�   .��5B   &     $ Delete=�6>   
�������$��20��6_   $��20��6k   5C   #   5E      5H      5K      5L      �� 5M      .+�5N      �  � ColumnDefinitions 5O      �� 5P      $��* �6+   67   �� 5Q      $��* �6+   67   .+�5S      �� $��1��6!   $ 
Horizontal=�62   $��Right=�6K   $��
0,10,30,10q�6g   .+�5T      �� -	   5        $ 	firstPage��5T   !   $��0,0,15,0q�6L   #���  6^   $ Previus��6�   .��5U        $ 	FirstPage=�66   $��24��6G   $��24��6S   5V      �� 5W      -
   5        $ prevPage��5W   "   $��0,0,15,0q�6K   #���  6]   $ Previus��6�   .��5X        $ PagePrevious=�66   $��24��6J   $��24��6V   5Y      �� 5Z      $��Center=�6%   $��Center=�6B   $ 
Horizontal=�6]   .+�5\      �� .��6$   	Showing6-   �� 5]      -   5         ��Name$
 dari��5]   (   $��Center=�66   $��Center=�6S   #��[ 6o   215^      �� 5_      .��6$   To6(   �� 5`      -   5        $ sampai��5`   (   $��Center=�68   $��Center=�6U   #��[ 6q   215a      �� 5b      .��6$   of6(   �� 5c      -   5        $ total��5c   (   $��Center=�67   $��Center=�6T   #��[ 6p   215d      �� 5e      .��6$   	entries6-   5f      �� 5h      -   5        $ nextPage��5h   !   $��15,0,0,0q�6J   #���  6\   $
 Next��6�   .��5i        $ PageNext=�66   $��24��6F   $��24��6R   5j      �� 5k      -   5        $ lastPage��5k   !   $��15,0,0,0q�6J   #���  6\   $ 	Last Page��6�   .��5l        $ LastPage=�66   $��24��6F   $��24��6R   5m      5n      �� 5o      $��0��6!   $ 
Horizontal=�61   $
��Left=�6L   $��
10,10,0,10q�6g   .+�5p      �� $��Center=�6$   $��Center=�6A   #��[ 6\   Jumlah data5q      �� 5r      -   5        $ 
cmbJumData��5r   #   $��Center=�68   $��Center=�6U   $��	10,0,0,10q�6p   #��[ 6�   .@�5s      ��  �� 
IsSelected . .��6=   106A   �� 5t      .��6+   206/   �� 5u      .��6+   306/   5w      5x      5y      5z      5{      5~      5�      