   M S B A M L   `   `   `  ����H  DPublicaciones, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Publicaciones.ConverterPublicaciones.Converter  5      E AUIControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:UIControls;assembly=UIControls
UIControls 5          Publicaciones.PorAutor   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      ;	converter%clr-namespace:Publicaciones.Converter     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      ?search,clr-namespace:UIControls;assembly=UIControls     5      p lTelerik.Windows.Controls.RibbonView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7m iTelerik.Windows.Controls.Docking, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a	 ]Telerik.Windows.Data, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7j
 fTelerik.Windows.Controls.Data, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.GridView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.Navigation, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Mtelerik1http://schemas.telerik.com/2008/xaml/presentation    	 
    5      -   5          � 	Resources  5      ,   &Publicaciones.Converter.ImageConverter   	imageConv0   *Publicaciones.Converter.TipoAutorConverter  	tipoAutor��%:   &	        &	        5   
   6#     5   
   6'   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��3* �6    � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��* �6   �� 5      $��40 �6   .+�5   
     UIControls.SearchTextBox  -   5        $��0��5      $��0��5      $��2��5      $	��200��5       $��21��5!      $��	10,10,0,0q�5"      $
��Left=�5#      $	��Top=�5$      5%      )  #Telerik.Windows.Controls.RadListBox  5'   
   -   5          Name$ 
LstAutores��5'      $��1��5(      $��0��5)      $��10,0,0,0q�5*      $��Stretch=�5+      $��Stretch=�5,       �� DisplayMemberPath$ Nombre��5-      $��16(�5.      >  8Telerik.Windows.Controls.Primitives.ItemsControlSelector   SelectedValuePath$ IdAutor��50      ��5/      �� 51      *  $Telerik.Windows.Controls.RadGridView  53   
   -   5          Name$ GObrasAutor��53      $��1��54      $��1��55      $��Stretch=�56      $��Stretch=�57      ;  5Telerik.Windows.Controls.GridView.GridViewDataControl   AutoGenerateColumns .     ShowGroupPanel .  * 	 $Telerik.Windows.Controls.DataControl	   ItemsSource	 59      �� 
   Columns
 5;      2	  ,Telerik.Windows.Controls.GridViewImageColumn	  5<      -
  'Telerik.Windows.Controls.GridViewColumn 
  Width?  9Telerik.Windows.Controls.GridView.GridViewLengthConverter$	 100 6.    
  IsFilterable .  6  0Telerik.Windows.Controls.GridViewBoundColumnBase   DataMemberBinding 5=   .   �� *Imagen+ �� 	Converter# [  5?   .   1  +Telerik.Windows.Controls.GridViewDataColumn  5A      $ * 6-      Header$ Título��5B   -    .   
  
IsReadOnly .  
  CellTemplate 5E      �� 5F      .R�5G      �� $��12(�6(   $
��Wrap=�5I   (   ��5H   (   �� *Titulo+5I   (   5J      5L        5N      $ * 6-   $ Sintesis��5O   -    .   .  5R      �� 5S      .R�5T      �� $	��150��6(   $��12(�5U   (   $
��Wrap=�5W   (   ��5V   (   �� *
Sintesis+5W   (   5X      5Z        5\      $ 80 6-   $ N. Material��5^   -    .  
  	IsVisible .  5]   -   �� *NumeroMaterial+5`   -     5a      $ 50 6-   $
 Año��5c   -    .  .  5b   -   �� *AnioPublicacion+5e   -     5f      $	 100 6-   $ Precio��5h   -    .  .  5g   -   �� *Precio+5j   -     5k      $	 150 6-   $
 ISBN��5m   -    .  .  5l   -   �� *Isbn+5o   -     5p      $ 50 6-   $ N. Pág.��5r   -    .   .  5q   -   �� *	Paginas+5t   -      RowStyle 5x      �� 5y       �� 
TargetType3  -Telerik.Windows.Controls.GridView.GridViewRow"  6   .�5z      ��  �� Property � �� �� Value 63   �� *IdTipoAutor+# [ 5{      5}      �� 5~   
   -   5        $��1��5~      $��29��5      $��30��5�      $��0,5,9,0q�5�      $��Right=�5�      $	��Top=�5�      $��Resources/colors.png��5�      5�      5�      