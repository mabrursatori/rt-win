   M S B A M L   `   `   `  ����@  <rtwin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:rtwin.View.Reportrtwin.View.Report  5      S OMaterialDesignExtensions, Version=2.7.0.0, Culture=neutral, PublicKeyToken=nullwQclr-namespace:MaterialDesignExtensions.Controls;assembly=MaterialDesignExtensions!MaterialDesignExtensions.Controls 5   W       rtwin.View.Report.daily   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:rtwin.View.Report     5      U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      `controlsQclr-namespace:MaterialDesignExtensions.Controls;assembly=MaterialDesignExtensions  6W   .��5
      � .+�5   
   �� $
��Left=�6   $	��Top=�6/   $	��950��6G   $	��523��6S      RectangleView#��[  6`   �� 5   
   $��Laporan Harian��6     MaterialDesignGroupBox#���  6+   $��
5,10,67,94q�6\   +  %MaterialDesignThemes.Wpf.ShadowAssist    ShadowDepth$  Depth3=�6p   $��0q�6�   .��5      �� .��5      � $	��Top=�6    � RowDefinitions 5      �� 5      $��0 �6(   65   �� 5      $��47 �6(   �� 5      $
��auto �6(   68   �� 5      $
��auto �6(   68   �� 5      $
��auto �6(   68   �� 5      $
��auto �6(   68   �� 5      $
��auto �6(   68   �� 5      $
��auto �6(   68   �� 5      $
��auto �6(   68   �� 5      $
��auto �6(   68   �� 5      $
��auto �6(   68   �� 5      $
��auto �6(   68   �� 5      $
��auto �6(   68    � ColumnDefinitions 5      �� 5       $	��140 �6+   69   �� 5!      $	��220 �6+   69   �� 5"      $	��150 �6+   69   �� 5#      $��0 �6+   67   �� 5$      $	��220 �6+   .+�5'      �� $��0��6    $��10,15,11,15q�6-      MaterialDesignBody2TextBlock#��[ 6C   $��0��6y   $��Center=�6�   $��17��6�   $��2��6�   	Tanggal6�   (  "System.Windows.Controls.DatePicker  5(      -   5          Name$ 	dtTanggal��5(   !   $��0��64   $��1��6A   $��	10,10,0,0q�6Q    ( $MaterialDesignFloatingHintDatePicker#��[ 6e   $��37��6�   $��2��6�   � 5*      $��2��6   $��5��6(   ���	#FFE2E4E4$��0 20 0 0q�6T   .+�5+      �� #��[ 6$   $��Center=�6[   $��10 0 0 0q�6v   Filter6�   5-      �� 5/      $��3��6    $��0��6-   $��10q�6=   #��[ 6I   NIP6�   �� 50      -   5         ��Name$ svNip��50   1   $��3��6$   $��Stretch=�6@   $��Stretch=�6^   $��10q�6z   $
��Auto=�51      $
��Auto=�6<   $��1��6_   .��52      �� $��Center=�6%   $
��auto��6B    �� Orientation$ Vertical=�6O   .+�53      :  4MaterialDesignExtensions.Controls.TextBoxSuggestions     TextBoxSuggestionsSource 6:   ��  �� Path$ TextBoxSuggestionsSource�   TextBox. 54   "   �� -   5        	 ��Name$	 txtNip��54   Q   $	��290��6*   $
��Left=�66   )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 Masukan Nama Atau Nip��6a    % !MaterialDesignFloatingHintTextBox#��[ 6�   ��6�   �� $
 Text� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�55      56      57      �� 59      $��4��6    $��0��6-   $��10q�6=   #��[ 6I   Deputi6�   �� 5:      -   5         ��Name$ 	cmbDeputi��5:      $��4��6\   $��1��6i   $��
10,10,7,10q�6y   $��28��6�   �� 5<      $��5��6    $��0��6-   $��10q�6=   #��[ 6I   Bagian/Bidang6�   �� 5=      -   5        $ 	cmbBagian��5=      $��5��6\   $��1��6i   $��
10,10,7,10q�6y   $��28��6�   �� 5?      $��6��6    $��0��6-   $��10q�6=   #��[ 6I   	Jabatan6�   �� 5@      -   5        $ 
cmbJabatan��5@      $��6��63   $��1��6@   $��
10,10,7,10q�6P   $��28��6d   �� 5B      $��7��6    $��0��6-   $��10q�6=   #��[ 6I   Grade6�   �� 5C      -   5        $ cmbGrade��5C      $��7��61   $��1��6>   $��
10,10,7,10q�6N   $��28��6b   �� 5E      $��8��6    $��0��6-   $��10q�6=   #��[ 6I   Status6�   �� 5F      -   5        $ 	cmbStatus��5F      $��8��62   $��1��6?   $��
10,10,7,10q�6O   $��28��6c   R� 5H      $	��220��6   $��9��6.   $��2��6;   R� 5J      $	��220��6   $��10��6.   $��2��6<   R� 5L      $	��220��6   $��11��6.   $��2��6<   �� 5M      -	   5        $��12��5M   8   $
��Auto��6F    � ToolTip$3 -MaterialDesignRaisedButton with Round Corners��6U   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��6�   $��12 5 0 0q�6�     MaterialDesignRaisedButton#��[ 6�   $��	Tampilkan��6  �� 5U      $��4��6    $��2��6-   $��	31,20,0,0q�6=   #��[ 6P   Status Biro6�   �� 5V      -
   5        $ cmbBiro��5V      $��4��6X   $��4��6e   $��
9,15,-69,5q�6u   $��28��6�   �� 5X      $��5��6    $��2��6-   $��	31,20,0,0q�6=   #��[ 6P   
Sub Bagian6�   �� 5Y      -   5        $ cmbSubbagian��5Y      $��5��65   $��4��6B   $��
9,15,-69,5q�6R   $��28��6f   �� 5[      $��6��6    $��2��6-   $��	31,20,0,0q�6=   #��[ 6P   
Golongan6�   �� 5\      -   5        $ cmbGolongan��5\      $��6��64   $��4��6A   $��
9,15,-69,5q�6Q   $��28��6e   �� 5^      $��7��6    $��2��6-   $��	31,20,0,0q�6=   #��[ 6P   Eselon6�   �� 5_      -   5        $ 	cmbEselon��5_      $��7��62   $��4��6?   $��
9,15,-69,5q�6O   $��28��6c   5c      5d      5f      5g      5h      