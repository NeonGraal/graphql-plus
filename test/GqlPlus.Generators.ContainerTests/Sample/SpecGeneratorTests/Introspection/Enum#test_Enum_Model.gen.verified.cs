//HintName: test_Enum_Model.gen.cs
// Generated from {CurrentDirectory}Enum.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Enum;

public class test_EnumLabel
  : test_Aliased
  , Itest_EnumLabel
{
  public Itest_EnumLabelObject? As__EnumLabel { get; set; }
}

public class test_EnumLabelObject
  : test_AliasedObject
  , Itest_EnumLabelObject
{
  public Itest_Name EnumType { get; set; }

  public test_EnumLabelObject
    ( Itest_Name enumType
    )
  {
    EnumType = enumType;
  }
}

public class test_EnumValue
  : test_TypeRef<Itest_TypeKind>
  , Itest_EnumValue
{
  public Itest_EnumValueObject? As__EnumValue { get; set; }
}

public class test_EnumValueObject
  : test_TypeRefObject<Itest_TypeKind>
  , Itest_EnumValueObject
{
  public Itest_Name Label { get; set; }

  public test_EnumValueObject
    ( Itest_Name label
    )
  {
    Label = label;
  }
}
