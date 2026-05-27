//HintName: test_Built-In_Model.gen.cs
// Generated from {CurrentDirectory}Built-In.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Built_In;

public class test_Collections
  : GqlpModelBase
  , Itest_Collections
{
  public ICollection<Itest_ACollection>? As_ACollection { get; set; }
  public Itest_CollectionsObject? As__Collections { get; set; }
}

public class test_CollectionsObject
  : GqlpModelBase
  , Itest_CollectionsObject
{

  public test_CollectionsObject
    ()
  {
  }
}

public class test_ACollection
  : GqlpModelBase
  , Itest_ACollection
{
  public Itest_Modifier<test_ModifierKind>? As_ModifierKindList { get; set; }
  public Itest_ModifierKeyed<test_ModifierKind>? As_ModifierKindDictionary { get; set; }
  public Itest_ModifierKeyed<test_ModifierKind>? As_ModifierKindTypeParam { get; set; }
  public Itest_ACollectionObject? As__ACollection { get; set; }
}

public class test_ACollectionObject
  : GqlpModelBase
  , Itest_ACollectionObject
{

  public test_ACollectionObject
    ()
  {
  }
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
    ( TModifierKind pmodifierKind
    , Itest_TypeSimple pby
    , bool pisOptional
    ) : base(pmodifierKind)
  {
    By = pby;
    IsOptional = pisOptional;
  }
}

public class test_Modifiers
  : GqlpModelBase
  , Itest_Modifiers
{
  public Itest_Modifier<test_ModifierKind>? As_ModifierKindRequired { get; set; }
  public ICollection<Itest_AModifier>? As_AModifier { get; set; }
  public Itest_ModifiersObject? As__Modifiers { get; set; }
}

public class test_ModifiersObject
  : GqlpModelBase
  , Itest_ModifiersObject
{

  public test_ModifiersObject
    ()
  {
  }
}

public class test_AModifier
  : GqlpModelBase
  , Itest_AModifier
{
  public Itest_Modifier<test_ModifierKind>? As_ModifierKindOptional { get; set; }
  public Itest_ACollection? As_ACollection { get; set; }
  public Itest_AModifierObject? As__AModifier { get; set; }
}

public class test_AModifierObject
  : GqlpModelBase
  , Itest_AModifierObject
{

  public test_AModifierObject
    ()
  {
  }
}

public class test_Modifier<TModifierKind>
  : GqlpModelBase
  , Itest_Modifier<TModifierKind>
{
  public Itest_ModifierObject<TModifierKind>? As__Modifier { get; set; }
}

public class test_ModifierObject<TModifierKind>
  : GqlpModelBase
  , Itest_ModifierObject<TModifierKind>
{
  public TModifierKind ModifierKind { get; set; }

  public test_ModifierObject
    ( TModifierKind pmodifierKind
    )
  {
    ModifierKind = pmodifierKind;
  }
}
