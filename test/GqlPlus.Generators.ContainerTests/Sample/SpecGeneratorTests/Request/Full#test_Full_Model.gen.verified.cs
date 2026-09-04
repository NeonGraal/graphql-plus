//HintName: test_Full_Model.gen.cs
// Generated from {CurrentDirectory}Full.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Full;

public class test_Request
  : GqlpModelBase
  , Itest_Request
{
  public string? AsString { get; set; }
  public Itest_RequestObject? As__Request { get; set; }
}

public class test_RequestObject
  : GqlpModelBase
  , Itest_RequestObject
{
  public Itest_Identifier? Category { get; set; }
  public Itest_Identifier? Operation { get; set; }
  public Itest_Operation Definition { get; set; }
  public object? Parameters { get; set; }

  public test_RequestObject
    ( Itest_Operation pdefinition
    )
  {
    Definition = pdefinition;
  }
}

public class test_Identifier
  : GqlpDomainString
  , Itest_Identifier
{
}

public class test_Collections
  : GqlpModelBase
  , Itest_Collections
{
  public Itest_Modifier<test_ModifierKind>? As_ModifierKindList { get; set; }
  public Itest_ModifierKeyed<test_ModifierKind>? As_ModifierKindDictionary { get; set; }
  public Itest_ModifierKeyed<test_ModifierKind>? As_ModifierKindTypeParam { get; set; }
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
  public Itest_Identifier By { get; set; }
  public bool IsOptional { get; set; }

  public test_ModifierKeyedObject
    ( TModifierKind pmodifierKind
    , Itest_Identifier pby
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
  public Itest_Modifier<test_ModifierKind>? As_ModifierKindOptional { get; set; }
  public Itest_Collections? As_Collections { get; set; }
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
