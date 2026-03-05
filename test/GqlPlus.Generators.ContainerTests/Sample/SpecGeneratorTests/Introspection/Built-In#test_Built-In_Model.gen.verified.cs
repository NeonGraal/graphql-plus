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

  public test_CollectionsObject
    ()
  {
  }
}

public class test_ModifierKeyed<TModifier>
  : test_Modifier<TModifier>
  , Itest_ModifierKeyed<TModifier>
{
  public Itest_ModifierKeyedObject<TModifier>? As__ModifierKeyed { get; set; }
}

public class test_ModifierKeyedObject<TModifier>
  : test_ModifierObject<TModifier>
  , Itest_ModifierKeyedObject<TModifier>
{
  public Itest_TypeSimple By { get; set; }
  public bool IsOptional { get; set; }

  public test_ModifierKeyedObject
    ( TModifier modifierKind
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

  public test_ModifiersObject
    ()
  {
  }
}

public class test_Modifier<TModifier>
  : GqlpModelImplementationBase
  , Itest_Modifier<TModifier>
{
  public Itest_ModifierObject<TModifier>? As__Modifier { get; set; }
}

public class test_ModifierObject<TModifier>
  : GqlpModelImplementationBase
  , Itest_ModifierObject<TModifier>
{
  public TModifier ModifierKind { get; set; }

  public test_ModifierObject
    ( TModifier modifierKind
    )
  {
    ModifierKind = modifierKind;
  }
}
