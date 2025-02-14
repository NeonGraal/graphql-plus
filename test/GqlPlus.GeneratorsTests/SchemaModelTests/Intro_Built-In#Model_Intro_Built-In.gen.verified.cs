//HintName: Model_Intro_Built-In.gen.cs
// Generated from Intro_Built-In.graphql+
/*
output _Constant {
    | _Simple
    | _ConstantList
    | _ConstantMap
    }
output _Simple {
    | Boolean
    | _DomainValue<_DomainKind.Number Number>
    | _DomainValue<_DomainKind.String String>
    | _EnumValue
}
output _ConstantList {
    | _Constant[]
    }
output _ConstantMap {
    | _Constant[Simple]
    }
output _Collections {
    | _Modifier<_ModifierKind.List>
    | _ModifierKeyed<_ModifierKind.Dictionary>
    | _ModifierKeyed<_ModifierKind.TypeParam>
    }
output _ModifierKeyed<$kind> {
    : _Modifier<$kind>
        by: _TypeSimple
        optional: Boolean
    }
output _Modifiers {
    | _Modifier<_ModifierKind.Optional>
    | _Collections
    }
enum _ModifierKind { Opt[Optional] List Dict[Dictionary] Param[TypeParam] }
output _Modifier<$kind> {
        modifierKind: $kind
    }
*/
namespace GqlPlus;
public class Model_Intro_Built-In {}