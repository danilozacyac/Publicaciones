   M S B A M L   `   `   `  ����E  AUIControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:UIControls;assembly=UIControls
UIControls  5   	    Publicaciones3   -Publicaciones.Mantenimiento.RelacionObraAutor   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ?search,clr-namespace:UIControls;assembly=UIControls     5   	   p lTelerik.Windows.Controls.RibbonView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7m iTelerik.Windows.Controls.Docking, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a	 ]Telerik.Windows.Data, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7j
 fTelerik.Windows.Controls.Data, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.GridView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.Navigation, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Mtelerik1http://schemas.telerik.com/2008/xaml/presentation    	 
    5   	   -   5          � Title$  RelacionObraAutor��5   	   $	��900��5   	   $	��600��5   	   .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $��50 �6   .+�5   
      UIControls.SearchTextBox  -   5        $��0��5      $��0��5      $	��200��5      $��21��5      $��10,10,10,10q�5      $
��Left=�5      $��Bottom=�5      5      *  $Telerik.Windows.Controls.RadGridView  5   
   -   5          Name$ 
GAutorObra��5      $��1��5      $��Stretch=�5      $��Stretch=�5      ;  5Telerik.Windows.Controls.GridView.GridViewDataControl   AutoGenerateColumns .     CanUserDeleteRows .     CanUserReorderColumns .     CanUserResizeColumns .     ShowGroupPanel .  * 	 $Telerik.Windows.Controls.DataControl   ItemsSource 5#      �� 	   Columns	 5%      1  +Telerik.Windows.Controls.GridViewDataColumn  5(      -  'Telerik.Windows.Controls.GridViewColumn
   Width?  9Telerik.Windows.Controls.GridView.GridViewLengthConverter$
 50 6-   6  0Telerik.Windows.Controls.GridViewBoundColumnBase   Header$ Id��5*   -      HeaderTextAlignment$ Center=�5+   -      	IsVisible .     IsFilterable .     
IsReadOnly .    DataMemberBinding 5)   -   �� *	IdAutor+5.   -     50      $
 * 6-   $ Nombre��52   -   $ Center=�53   -    .   .  51   -   �� *Nombre+55   -   5	  /Telerik.Windows.Controls.GridViewCheckBoxColumn	  57      $
 60 61    	  AutoSelectOnEdit .    EditTriggers$ 	CellClick=�5;   1   $ Autor��5<   1   $ Center=�5=   1    .  59   1   �� *	IsAutor+ �� Mode$ TwoWay=�5>   1   	  5?      $
 75 61    . $ 	CellClick=�5C   1   $ 
Compilador��5D   1   $ Center=�5E   1    .  5A   1   �� *IsCompilador+$ TwoWay=�5F   1   	  5G      $
 75 61    . $ 	CellClick=�5K   1   $ 	Traductor��5L   1   $ Center=�5M   1    .  5I   1   �� *IsTraductor+$ TwoWay=�5N   1   	  5O      $
 75 61    . $ 	CellClick=�5S   1   $ Coordinador��5T   1   $ Center=�5U   1    .  5Q   1   �� *IsCoordinador+$ TwoWay=�5V   1   	  5W      $
 75 61    . $ 	CellClick=�5[   1   $ Comentarista��5\   1   $ Center=�5]   1    .  5Y   1   �� *IsComentarista+$ TwoWay=�5^   1   	  5_      $
 75 61    . $ 	CellClick=�5c   1   $ Coeditor��5d   1   $ Center=�5e   1    .  5a   1   �� *IsCoedicion+$ TwoWay=�5f   1   	  5g      $
 75 61    . $ 	CellClick=�5k   1   $ Estudio In.��5l   1   $ Center=�5m   1    .  5i   1   �� *	IsEstudio+$ TwoWay=�5n   1   	  5o      $
 75 61    . $ 	CellClick=�5s   1   $ Prologuista��5t   1   $ Center=�5u   1    .  5q   1   �� *	IsPrologo+$ TwoWay=�5v   1   5y      (
  "Telerik.Windows.Controls.RadButton
  5z   
   -   5         
 Name$ 
BtnGuardar��5z      $��2��5{      $��80��5|      $��30��5}      $��	0,10,10,0q�5~      $��Right=�5      $	��Top=�5�      $��Guardar��5�      
  5�   
   -   5        $��BtnAddAutor��5�      $��2��5�      $	��120��5�      $��30��5�      $��	24,10,0,0q�5�      $
��Left=�5�      $	��Top=�5�      $��Agregar autor��5�      5�      5�      