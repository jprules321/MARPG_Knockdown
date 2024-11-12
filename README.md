"# MARPG_Knockdown" 


You will need to put the overrides from <<CustomPlayerCharacterEntity_Knockdown.cs>> for CanAttack and CanDoActions to your own class if you use them anywhere else.

TODO : Add a dedicated animation slot for Knockdown. Right now it uses Slot 0 in CustomAnimation array.
TODO : Add Knockdown duration to gameplay rule (Right now is hardcoded to 5 seconds in Knockdown Coroutine
TODO : Add Reduce Knockdown time stat