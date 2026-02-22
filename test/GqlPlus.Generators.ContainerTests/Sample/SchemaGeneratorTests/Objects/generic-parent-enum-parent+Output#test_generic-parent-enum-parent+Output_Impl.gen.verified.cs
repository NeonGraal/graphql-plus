//HintName: test_generic-parent-enum-parent+Output_Impl.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_parent_Output;

public class testGnrcPrntEnumPrntOutp
  : testFieldGnrcPrntEnumPrntOutp<testEnumGnrcPrntEnumPrntOutp>
  , ItestGnrcPrntEnumPrntOutp
{
  public ItestGnrcPrntEnumPrntOutpObject? As_GnrcPrntEnumPrntOutp { get; set; }
}

public class testGnrcPrntEnumPrntOutpObject
  : testFieldGnrcPrntEnumPrntOutpObject<testEnumGnrcPrntEnumPrntOutp>
  , ItestGnrcPrntEnumPrntOutpObject
{

  public testGnrcPrntEnumPrntOutpObject(testEnumGnrcPrntEnumPrntOutp field)
    : base(field)
  {
  }
}

public class testFieldGnrcPrntEnumPrntOutp<TRef>
  : GqlpModelImplementationBase
  , ItestFieldGnrcPrntEnumPrntOutp<TRef>
{
  public ItestFieldGnrcPrntEnumPrntOutpObject<TRef>? As_FieldGnrcPrntEnumPrntOutp { get; set; }
}

public class testFieldGnrcPrntEnumPrntOutpObject<TRef>
  : GqlpModelImplementationBase
  , ItestFieldGnrcPrntEnumPrntOutpObject<TRef>
{
  public TRef Field { get; set; }

  public testFieldGnrcPrntEnumPrntOutpObject(TRef field)
  {
    Field = field;
  }
}
