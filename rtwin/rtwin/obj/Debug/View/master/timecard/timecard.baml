   M S B A M L   `   `   `  ����@  <rtwin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:rtwin.View.master.timecardrtwin.View.master.timecard  5      )    #rtwin.View.master.timecard.timecard   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:rtwin.View.master.timecard     5      U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      .��5
      �   � RowDefinitions  5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   .+�5   
   �� $��3��6    �� RadiusX$ 20��6%   $
��Left=�62   $	��Top=�6M    �� RadiusY$ 20��6e   $
��1050��6r   $	��523��6      RectangleView#��[  6�   �� 5   
   5      �� 5   
   $��0��6    �� Orientation$ 
Horizontal=�6"   $
��Left=�6;   .+�5      � $	��134��6   .+�5      �� -   5         ��Name$ 
btnAddData��5        GreenButton#���  6F   $��30��6l    � ToolTip$3 -MaterialDesignRaisedButton with Round Corners��6y   #��� ��6�   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��6�   $��5 5 0 0q�6+  .��5      �� 
�������$��Tambah Data��63   5      5       5!      �� 5"   
   $��0��6   $ 
Horizontal=�6"   $��Right=�6;   $��0,0,20,0q�6W   .+�5#      �� $��	0,15,20,0q�6   $��Center=�6+   $��Center=�6H    " MaterialDesignCaptionTextBlock#��[ 6c   Urutkan Berdasar5$      �� 5%      -   5         ��Name$ cmbSort��5%      $��Center=�6T   $��Center=�6q    & "MaterialDesignFloatingHintComboBox#��[ 6�   5(      �� 5)      -   5        $ btnSort��5)   '   $��10,5,0,0q�6     ButtonPagination#���  6O   $
��Left=�6z   .��5*      '  !MaterialDesignThemes.Wpf.PackIcon  -   5          Name$ 	arrowSort��5*   *   �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]	   Kind$	 ArrowUp=�6=   $��24��6L   $��24��6X   5+      5,      �� 5-   
   $��1��6   $ Vertical=�6"   $��Stretch=�6:   .+�5/      &   System.Windows.Controls.DataGrid  -   5        
  Name$
 
dgTimeCard��5/      $��5 5 10 0q�6+      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6=      CanUserAddRows .     
IsReadOnly .    Columns 51      4  .System.Windows.Controls.DataGridTemplateColumn  52      ,  &System.Windows.Controls.DataGridColumn   Header$
 Edit��6-   -   5        edit_header��   CellTemplate 53      �� 54      .R�55   "   �� $
 edit��6)   -   5        $��30��55   J   $��30��6V     
ButtonEdit#���  6a   $
 Edit��6�   
�������.��57   &     $
	 Edit=�6>   $��24��6J   $��24��6V   58   #   5:      5=        5>      $ Hapus��6-   -   5        hapus_header�� 5?      �� 5@      .R�5A   "   �� $ hapus��6)   -	   5        $��30��5A   L   $��30��6W     ButtonDelete#���  6c   $ Hapus��6�   
�������.��5B   &     $	 Delete=�6>   $��20��6L   $��20��6X   5C   #   5E      5H      5K      �� 5L      $��2��6   .+�5M      �  � ColumnDefinitions 5N      �� 5O      $��* �6+   67   �� 5P      $��* �6+   67   .+�5R      �� $��1��6!   $ 
Horizontal=�62   $	��Top=�6K   $��Right=�6c   $��	0,5,30,10q�6   .+�5S      �� -
   5        $ 	firstPage��5S   !   $��0,0,15,0q�6L   #���  6^   $ Previus��6�   .��5T        $	 	FirstPage=�66   $��24��6G   $��24��6S   5U      �� 5V      -   5        $ prevPage��5V   "   $��0,0,15,0q�6K   #���  6]   $ Previus��6�   .��5W        $	 PagePrevious=�66   $��24��6J   $��24��6V   5X      �� 5Y      $��Center=�6%   $��Center=�6B   $ 
Horizontal=�6]   .+�5[      �� .��6$   	Showing6-   �� 5\      -   5         ��Name$
 dari��5\   (   $��Center=�66   $��Center=�6S   #��[ 6o   215]      �� 5^      .��6$   To6(   �� 5_      -   5        $ sampai��5_   (   $��Center=�68   $��Center=�6U   #��[ 6q   215`      �� 5a      .��6$   of6(   �� 5b      -   5        $ total��5b   (   $��Center=�67   $��Center=�6T   #��[ 6p   215c      �� 5d      .��6$   	entries6-   5e      �� 5g      -   5        $ nextPage��5g   !   $��15,0,0,0q�6J   #���  6\   $
 Next��6�   .��5h        $	 PageNext=�66   $��24��6F   $��24��6R   5i      �� 5j      -   5        $ lastPage��5j   !   $��15,0,0,0q�6J   #���  6\   $ 	Last Page��6�   .��5k        $	 LastPage=�66   $��24��6F   $��24��6R   5l      5m      �� 5n      $ 
Horizontal=�6"   $	��Top=�6;   $
��Left=�6U   $��	10,0,0,10q�6p   .+�5o      �� $��Center=�6$   $��Center=�6A   #��[ 6\   Jumlah data5p      �� 5q      -   5        $ 
cmbJumData��5q   #   $��Center=�68   $��Center=�6U   $��	10,0,0,10q�6p   #��[ 6�   .@�5r      ��  �� 
IsSelected . .��6=   106A   �� 5s      .��6+   206/   �� 5t      .��6+   306/   5v      5w      5x      5y      5z      5}      5~      