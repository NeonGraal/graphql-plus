namespace GqlPlus.Schema.Modelling;

internal sealed class SchModifierModeller
  : ModellerBase<IAstModifier, ISch_Modifiers>
{
  internal static IModeller<IAstModifier, ISch_Modifiers> Factory(ISchModellerRepository _)
    => new SchModifierModeller();
  protected override ISch_Modifiers ToModel(IAstModifier ast, IMap<GqlpTypeKind> typeKinds)
    => ast.ModifierKind switch {
      ModifierKind.Opt => MakeOptional(),
      ModifierKind.List => MakeList(),
      ModifierKind.Dict => MakeKeyed(Sch_ModifierKind.Dict, ast.Key, ast.IsOptional, typeKinds, true),
      ModifierKind.Param => MakeKeyed(Sch_ModifierKind.Param, ast.Key, ast.IsOptional, typeKinds, false),
      _ => MakeOptional(),
    };

  private static Sch_Modifiers MakeOptional()
    => new Sch_Modifiers {
      As_ModifierKindOptional = new Sch_Modifier<Sch_ModifierKind> {
        As__Modifier = new Sch_ModifierObject<Sch_ModifierKind>(Sch_ModifierKind.Opt),
      },
      As__Modifiers = new Sch_ModifiersObject(),
    };

  private static Sch_Modifiers MakeList()
    => new Sch_Modifiers {
      As_Collections = new Sch_Collections {
        As_ModifierKindList = new Sch_Modifier<Sch_ModifierKind> {
          As__Modifier = new Sch_ModifierObject<Sch_ModifierKind>(Sch_ModifierKind.List),
        },
        As__Collections = new Sch_CollectionsObject(),
      },
      As__Modifiers = new Sch_ModifiersObject(),
    };

  private static Sch_Modifiers MakeKeyed(
    Sch_ModifierKind kind,
    string key,
    bool isOptional,
    IMap<GqlpTypeKind> typeKinds,
    bool isDictionary
  )
  {
    Sch_ModifierKeyed<Sch_ModifierKind> keyed = new() {
      As__Modifier = new Sch_ModifierObject<Sch_ModifierKind>(kind),
      As__ModifierKeyed = new Sch_ModifierKeyedObject<Sch_ModifierKind>(kind, SchModellerHelpers.MakeTypeSimple(key, typeKinds), isOptional),
    };

    Sch_Collections collections = new() {
      As__Collections = new Sch_CollectionsObject(),
    };

    if (isDictionary) {
      collections.As_ModifierKindDictionary = keyed;
    } else {
      collections.As_ModifierKindTypeParam = keyed;
    }

    return new Sch_Modifiers {
      As_Collections = collections,
      As__Modifiers = new Sch_ModifiersObject(),
    };
  }
}
