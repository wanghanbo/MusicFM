;#DropDB MusicFMEasyTest

#Application MusicFM.Win
#Application MusicFM.Web
#IfDef MusicFM.Win

*Action About...
 
*Action OK

#EndIf

#IfDef MusicFM.Web
!Action Navigation(My Details)
#EndIf
