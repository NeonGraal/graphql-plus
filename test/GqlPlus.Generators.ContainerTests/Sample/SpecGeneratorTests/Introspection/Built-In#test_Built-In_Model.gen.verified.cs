//HintName: test_Built-In_Model.gen.cs
// Generated from {CurrentDirectory}Built-In.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Built_In;

public class test_Collections
  : GqlpModelImplementationBase
  , Itest_Collections
{
  public Itest_Modifier<test_ModifierKind>? As_ModifierKindList { get; set; }
  public Itest_ModifierKeyed<test_ModifierKind>? As_ModifierKindDictionary { get; set; }
  public Itest_ModifierKeyed<test_ModifierKind>? As_ModifierKindTypeParam { get; set; }
  public Itest_CollectionsObject? As__Collections { get; set; }
}

public class test_CollectionsObject
  : GqlpModelImplementationBase
  , Itest_CollectionsObject
{
}

public class test_ModifierKeyed<TModifierKind>
  : test_Modifier<TModifierKind>
  , Itest_ModifierKeyed<TModifierKind>
{
  public Itest_ModifierKeyedObject<TModifierKind>? As__ModifierKeyed { get; set; }
}

public class test_ModifierKeyedObject<TModifierKind>
  : test_ModifierObject<TModifierKind>
  , Itest_ModifierKeyedObject<TModifierKind>
{
  public Itest_TypeSimple By { get; set; }
  public bool IsOptional { get; set; }

  public test_ModifierKeyedObject
    ( TModifierKind modifierKind
    , Itest_TypeSimple by
    , bool isOptional
    ) : base(modifierKind)
  {
    By = by;
    IsOptional = isOptional;
  }
}

public class test_Modifiers
  : GqlpModelImplementationBase
  , Itest_Modifiers
{
  public Itest_Modifier<test_ModifierKind>? As_ModifierKindOptional { get; set; }
  public Itest_Collections? As_Collections { get; set; }
  public Itest_ModifiersObject? As__Modifiers { get; set; }
}

public class test_ModifiersObject
  : GqlpModelImplementationBase
  , Itest_ModifiersObject
{
}

public class test_Modifier<TModifierKind>
  : GqlpModelImplementationBase
  , Itest_Modifier<TModifierKind>
{
  public Itest_ModifierObject<TModifierKind>? As__Modifier { get; set; }
}

public class test_ModifierObject<TModifierKind>
  : GqlpModelImplementationBase
  , Itest_ModifierObject<TModifierKind>
{
  public TModifierKind ModifierKind { get; set; }

  public test_ModifierObject
    ( TModifierKind modifierKind
    )
  {
    ModifierKind = modifierKind;
  }
}
