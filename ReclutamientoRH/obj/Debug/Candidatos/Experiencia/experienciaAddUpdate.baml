   M S B A M L   `   `   `  ����J  FReclutamientoRH, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:ReclutamientoRH.Candidatos.Experiencia&ReclutamientoRH.Candidatos.Experiencia  5   	   A%clr-namespace:ReclutamientoRH.HelpersReclutamientoRH.Helpers  5   	   A    ;ReclutamientoRH.Candidatos.Experiencia.experienciaAddUpdate   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Flocal4clr-namespace:ReclutamientoRH.Candidatos.Experiencia     5   	   8helper%clr-namespace:ReclutamientoRH.Helpers     5   	     � Icon$  
/Icono.ico��5	   	    � Title$, &Añadir/Actualizar Experiencia Laboral��5
   	   $	��350��5   	   $	��350��6    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��125 �6   �� 5      $	��225 �6    � RowDefinitions 5   
   �� 5      $��75 �6   �� 5      $	��150 �6   �� 5      $	��125 �6   .+�5   
   �� -   5        $��Empresa��5   /   $��1��6   $��1��6    �� MaxLines$ 2��6>   $
��Left=�6K   $��0,5,0,0q�6f   $�� ��6w    �� TextWrapping$
 Wrap=�6   $	��Top=�6�   $	��175��6�   $��18��6�    �� 	MaxLength$ 45��6�   �� 5   
   -   5        $��Puesto��5   /   $��1��6   $��1��6   $ 2��6=   $
��Left=�6J   $��0,30,0,0q�6e   $�� ��6w   $
 Wrap=�6   $	��Top=�6�   $	��175��6�   $��18��6�   $ 25��6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��
FechaDesde��5   A   	   DisplayDate$	  ��6   $��1��6$   $��1��61   $
��Left=�6S   $��0,53,0,0q�6n   
   Text$
  ��6�   $	��Top=�6�   $	��175��6�   $��24��6�     5   
   -   5        $��
FechaHasta��5   A   $	  ��6   $��1��6$   $��1��61   $
��Left=�6S   $��0,79,0,0q�6n   $
  ��6�   $	��Top=�6�   $	��175��6�   $��24��6�   ,   &ReclutamientoRH.Helpers.NumericTextBox  5   
   -   5          Name$ Salario��5   `   $��Right=�6    $��1��6C   $��1��6P   $ 2��6q   $
��Left=�6~   $��	0,105,0,0q�6�   $�� ��6�   $
 Wrap=�6�   $	��Top=�6�   $	��175��6�   $��18��6�      IsDecimalAllowed . $ 20��6     Scale$ 2��6  {�. 6)  �� 5   
   $��1��6   $��0��6   $��Empresa:��6-   $��0,0,0,0q�6@   $��Right=�6Q   $	��Top=�6t   $��26��6�   �� 5    
   $��1��6   $��0��6   $��Puesto:��6-   $��0,25,0,0q�6?   $��Right=�6Q   $	��Top=�6t   $��26��6�   �� 5!   
   $��1��6   $��0��6   $��Fecha de Inicio:��6-   $��0,50,0,0q�6H   $��Right=�6Z   $	��Top=�6}   $��26��6�   �� 5"   
   $��1��6   $��0��6   $��Fecha de Término:��6-   $��0,75,0,0q�6I   $��Right=�6[   $	��Top=�6~   $��26��6�   �� 5#   
   $��1��6   $��0��6   $��Salario:��6-   $��	0,100,0,0q�6@   $��Right=�6S   $	��Top=�6v   $��26��6�   �� 5%   
   -   5        $
��Info��5%      $-��'Crear/Modificar su Experiencia Laboral:��6   $��Center=�6N   $��Center=�6r   $��0,20,0,0q�6�   $	��Top=�6�   $��12(�6�   $��2��6�   $��26��6�   $	��250��6�   �� 5&   
   -   5        $��AgregarActualizar��5&      $��Agregar/Actualizar��6*   $��Center=�6G   $��134,15,134,0q�6d   $��2��6z   $	��Top=�6�   $��76��6�   $��2��6�   $��20��6�   �� 5'   
   -   5        $��Cancelar��5'      $��Center=�6$   $��134,45,134,0q�6A   $��2��6W   $	��Top=�6d   $��76��6|   $��2��6�   $��20��6�   5)      5*      