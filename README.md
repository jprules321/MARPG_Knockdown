
# MARPG Knockdown system

Knockdown system for Multiplayer ARPG by Suri


## NOTE

You will need to put the overrides from <<CustomPlayerCharacterEntity_Knockdown.cs>> for CanAttack and CanDoActions to your own class if you use them anywhere else.

## FEATRUES
- Dedicated knockdown animation slot on PlayerCharacterModel
- Knockdown chance stat
- Knockdown Cooldown Stat (How long before your character can be knocked down again after getting up) You can increase or decrease this with Buff and debuff or stat gears.
- Knockdown Duration (How long your character gets knocked for in seconds ) You can increase or decrease this with Buff and debuff or stat gears.
- New gameplay rules related to Knockdown

## TODO

- ~~Add a dedicated animation slot for Knockdown. Right now it uses Slot 0 in CustomAnimation array.~~
- ~~Add Knockdown duration to gameplay rule (Right now is hardcoded to 5 seconds in Knockdown Coroutine~~
- ~~Add Reduce Knockdown time stat~~


