   M S B A M L   `   `   `  ����J  FReclutamientoRH, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:ReclutamientoRH.RecursosHumanos.Puestos'ReclutamientoRH.RecursosHumanos.Puestos  5   	   A%clr-namespace:ReclutamientoRH.HelpersReclutamientoRH.Helpers  5   	   >    8ReclutamientoRH.RecursosHumanos.Puestos.puestosAddUpdate   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Glocal5clr-namespace:ReclutamientoRH.RecursosHumanos.Puestos     5   	   8helper%clr-namespace:ReclutamientoRH.Helpers     5   	     � Icon$  
/Icono.ico��5	   	    � Title$  Añadir/Actualizar Puestos��5
   	   $	��350��5   	   $	��350��6    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��175 �6   �� 5      $	��175 �6    � RowDefinitions 5   
   �� 5      $��75 �6   �� 5      $	��150 �6   �� 5      $	��125 �6   .+�5   
   �� -   5        $��Nombre��5   /   $��1��6   $��1��6    �� MaxLines$ 2��6=   $
��Left=�6J   $��0,5,0,0q�6e   $�� ��6v    �� TextWrapping$
 Wrap=�6~   $	��Top=�6�   $	��125��6�   $��18��6�    �� 	MaxLength$ 40��6�   �� 5   
   -   5        $��Departamento��5   /   $��1��6   $��1��6   $ 2��6C   $
��Left=�6P   $��0,30,0,0q�6k   $�� ��6}   $
 Wrap=�6�   $	��Top=�6�   $	��125��6�   $��18��6�   $ 40��6�   ,   &ReclutamientoRH.Helpers.NumericTextBox  5   
   -   5        	  Name$	 NivelMinSalario��5      $��Right=�5      $��1��5      $��1��6   $ 2��5      $
��Left=�5       $��0,80,0,0q�5!      $�� ��5"      $
 Wrap=�5#      $	��Top=�5$      $	��125��5%      $��18��6   
   IsDecimalAllowed
 . $ 20��5(         Scale$ 2��5)      {�. 5*        5,   
   -   5        $	 NivelMaxSalario��5,   `   $��Right=�6    $��1��6C   $��1��6P   $ 2��6y   $
��Left=�6�   $��	0,105,0,0q�6�   $�� ��6�   $
 Wrap=�6�   $	��Top=�6�   $	��125��6�   $��18��6�   
 . $ 20��6  $ 2��6'  {�. 61  �� 51   
   -   5        $��NivelDeRiesgo��51   �    �� 
IsEditable .  $��1��6&   $��1��63   $��20��6C   $	��125��6O   $��0,53,0,0q�6[   $
��Left=�6m   $	��Top=�6�    �� SelectedIndex$ -1��6�   .@�52      �� $
��Bajo��6   6,   �� 53      $��Medio��6   6-   �� 54      $
��Alto��6   6,   55      �� 57   
   $��1��6   $��0��6   $��Nombre:��6-   $��0,0,0,0q�6?   $��Right=�6P   $	��Top=�6s   $��26��6�   �� 58   
   $��1��6   $��0��6   $��Departamento:��6-   $��0,25,0,0q�6E   $��Right=�6W   $	��Top=�6z   $��26��6�   �� 59   
   $��1��6   $��0��6   $��Nivel de Riesgo:��6-   $��0,50,0,0q�6H   $��Right=�6Z   $	��Top=�6}   $��26��6�   �� 5:   
   $��1��6   $��0��6   $��Nivel de Salario Minimo:��6-   $��0,75,0,0q�6P   $��Right=�6b   $	��Top=�6�   $��26��6�   �� 5;   
   $��1��6   $��0��6   $��Nivel de Salario Maximo:��6-   $��	0,100,0,0q�6P   $��Right=�6c   $	��Top=�6�   $��26��6�   �� 5=   
   -   5        $
��Info��5=      $%��Crear una vacante de un puesto:��6   $��Center=�6F   $��
82,20,82,0q�6c   $	��Top=�6w   $��12(�6�   $��2��6�   $��26��6�   $	��180��6�   �� 5>   
   -   5        $��AgregarActualizar��5>      $��Agregar/Actualizar��6*   $��Center=�6G   $��134,15,134,0q�6d   $��2��6z   $	��Top=�6�   $��76��6�   $��2��6�   $��20��6�   �� 5?   
   -   5        $��Cancelar��5?      $��Center=�6$   $��134,45,134,0q�6A   $��2��6W   $	��Top=�6d   $��76��6|   $��2��6�   $��20��6�   5@      5A      