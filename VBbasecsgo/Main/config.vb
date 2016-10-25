
' ___  _    ___ ___   __  __ ___ 
'|   \| |  | _ \ __| |  \/  | __|
'| |) | |__|  _/ _| _| |\/| | _| 
'|___/|____|_| |___(_)_|  |_|___|
'
'Author: Dlpe (DLPE.me) + unknowncheats.me members
'Funny and shitty code... Do not learn from this project
'

Namespace csgo
    Module config
        'Aim
        Public aim_onoff As Integer = 1 '1 - on 0 - off
        Public fov As Integer = 3
        Public smooth As Integer = 1
        Public hitbox As Integer = 6
        'RCS
        Public rcs_onoff As Integer = 1 '1 - on 0 - off
        'Glow
        Public glowteamenabled As Boolean = True
        Public glowenemyenabled As Boolean = True
        Public glow_alpha As Integer = 230
        Public glow_enemy_r As Integer = 225
        Public glow_enemy_g As Integer = 0
        Public glow_enemy_b As Integer = 0
        Public glow_team_r As Integer = 0
        Public glow_team_g As Integer = 225
        Public glow_team_b As Integer = 0
        'Trigger
        Public trigger_onoff As Integer = 1 '1 - on 0 - off
        Public trigger_key As Integer = &H18
        Public trigger_delay As Integer = 40
        'Misc
        Public noflash_onoff As Integer = 1 '1 - on 0 - off
        Public autopistol_key = &H17
        Public bunnyhop_key = &H32
    End Module
End Namespace

