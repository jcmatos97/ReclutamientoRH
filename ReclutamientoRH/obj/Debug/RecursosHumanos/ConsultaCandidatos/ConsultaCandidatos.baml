   M S B A M L   `   `   `  ����J  FReclutamientoRH, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullw@clr-namespace:ReclutamientoRH.RecursosHumanos.ConsultaCandidatos2ReclutamientoRH.RecursosHumanos.ConsultaCandidatos  5      A%clr-namespace:ReclutamientoRH.HelpersReclutamientoRH.Helpers  5      K    EReclutamientoRH.RecursosHumanos.ConsultaCandidatos.ConsultaCandidatos   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Rlocal@clr-namespace:ReclutamientoRH.RecursosHumanos.ConsultaCandidatos     5      8helper%clr-namespace:ReclutamientoRH.Helpers     5        N� Title$  Puestos��5
       N� 
Background
 �����.��5      � .+�5   
   �� $��Consultar Candidatos��6   $
��Left=�6/   $��10,0,0,0q�6J   $	��Top=�6\   $��30(�6t   �� 5   
   -   5        $
��Left=�5      $	��Top=�6,   $	��100��6D   $��250,100,0,0q�6P   .��6w   	Consultar6�   �� 5   
   -   5        $
��Left=�5      $	��Top=�6,   $	��100��6D   $��355,100,0,0q�6P   .��6{   Limpiar Campos6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��Tabla��5      $	��Top=�6    $
��Left=�68      AutoGenerateColumns .     
IsReadOnly . $��
10,130,0,0q�6�   $	��685��6�   $	��685��6�   $	��285��6�   $	��285��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Nombre��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *Nombre+6R     5      $ Cedula��6%    65   �� *Cedula+6R     5      $ Usuario��6%    66   �� *	Usuario+6T     5      $ Puesto Solicitado��6%    6@   �� *Puesto+6]     5      $ Aspiración Salarial��6%    6B   �� *SalarioAspiracion+   ElementStyle 5      �� 5       �� 
TargetType" ��6    .�5      �� 	 �� Property	 � ��
 �� Value$
 Right=�6D   5      5        5       $ Recomendado por��6%    6>   �� *RecomendadoPor+6c   4  .System.Windows.Controls.DataGridTemplateColumn  5!      $ Opciones��6)      CellTemplate 5"      �� 5#      .R�5$      ��  �� Orientation$ 
Horizontal=�6)   .+�5%   "   �� -   5        $��75��5%   Y   ��6)   �� *Id+.��6d   	Detalle6m   �� 5&   "   -   5        $	��125��5&   f   ��6)   �� *Id+.��6r   Seleccionar Candidato6�   5'      5(      5*      5,      �� 5-   
   $��Nombre:��6   $
��Left=�6"   $��	10,45,0,0q�6=   $	��Top=�6P   �� 5.   
   -   5        $��Nombre��5.      $
��Left=�6    $��18��6;   $��	65,50,0,0q�6G    �� TextWrapping$
 Wrap=�6Z   $�� ��6n   $	��Top=�6v   $	��145��6�    �� 	MaxLength$ 45��6�   �� 5/   
   $��Cedula:��6   $
��Left=�6"   $��
214,45,0,0q�6=   $	��Top=�6Q   �� 50   
   -   5        $��Cedula��50      $
��Left=�6    $��18��6;   $��
262,50,0,0q�6G   $
 Wrap=�6[   $�� ��6o   $	��Top=�6w   $��90��6�   $ 11��6�   �� 51   
   $��Usuario:��6   $
��Left=�6#   $��
355,45,0,0q�6>   $	��Top=�6R   �� 52   
   -   5        $��Usuario��52      $
��Left=�6!   $��18��6<   $��
407,50,0,0q�6H   $
 Wrap=�6\   $�� ��6p   $	��Top=�6x   $��90��6�   $ 20��6�   �� 53   
   $��Puesto Solicitado:��6   $
��Left=�6-   $��
500,45,0,0q�6H   $	��Top=�6\   �� 54   
   -	   5        $��Puesto��54      $
��Left=�6    $��18��6;   $��
603,50,0,0q�6G   $
 Wrap=�6[   $�� ��6o   $	��Top=�6w   $��90��6�   $ 40��6�   �� 56   
   $��Rango Salarial - Desde:��6   $
��Left=�62   $��	10,70,0,0q�6M   $	��Top=�6`   ,   &ReclutamientoRH.Helpers.NumericTextBox  57   
   -
   5          Name$ SalarioDesde��57       $
��Left=�66   $��18��6Q   $��
140,75,0,0q�6]   $
 Wrap=�6q   $�� ��6�   $	��Top=�6�   $	��100��6�   $��Right=�6�      IsDecimalAllowed . $ 20��58         Scale$ 2��59      {�. 5:      �� 5;   
   $��Rango Salarial - Hasta:��6   $
��Left=�62   $��
245,70,0,0q�6M   $	��Top=�6a     5<   
   -   5        $ SalarioHasta��5<       $
��Left=�66   $��18��6Q   $��
372,75,0,0q�6]   $
 Wrap=�6q   $�� ��6�   $	��Top=�6�   $	��100��6�   $��Right=�6�    . $ 20��5=      $ 2��5>      {�. 5?      �� 5A   
   $��Recomendado por:��6   $
��Left=�6+   $��
480,70,0,0q�6F   $	��Top=�6Z   �� 5B   
   -   5        $��RecomendadoPor��5B      $
��Left=�6(   $��18��6C   $��
590,75,0,0q�6O   $
 Wrap=�6c   $�� ��6w   $	��Top=�6   $	��103��6�   $ 30��6�   5D      5E      