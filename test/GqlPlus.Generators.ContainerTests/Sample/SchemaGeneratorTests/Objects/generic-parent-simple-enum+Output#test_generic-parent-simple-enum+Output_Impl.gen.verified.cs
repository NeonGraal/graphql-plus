//HintName: test_generic-parent-simple-enum+Output_Impl.gen.cs
// Generated from {CurrentDirectory}generic-parent-simple-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_simple_enum_Output;

public class testGnrcPrntSmplEnumOutp
  : testFieldGnrcPrntSmplEnumOutp<testEnumGnrcPrntSmplEnumOutp>
  , ItestGnrcPrntSmplEnumOutp
{
  public ItestGnrcPrntSmplEnumOutpObject? As_GnrcPrntSmplEnumOutp { get; set; }
}

public class testGnrcPrntSmplEnumOutpObject
  : testFieldGnrcPrntSmplEnumOutpObject<testEnumGnrcPrntSmplEnumOutp>
  , ItestGnrcPrntSmplEnumOutpObject
{

  public testGnrcPrntSmplEnumOutpObject(TRef field)
    : base(field)
  {
  }
}

public class testFieldGnrcPrntSmplEnumOutp<TRef>
  : GqlpModelImplementationBase
  , ItestFieldGnrcPrntSmplEnumOutp<TRef>
{
  public ItestFieldGnrcPrntSmplEnumOutpObject<TRef>? As_FieldGnrcPrntSmplEnumOutp { get; set; }
}

public class testFieldGnrcPrntSmplEnumOutpObject<TRef>
  : GqlpModelImplementationBase
  , ItestFieldGnrcPrntSmplEnumOutpObject<TRef>
{
  public TRef Field { get; set; }

  public testFieldGnrcPrntSmplEnumOutpObject(TRef field)
  {
    Field = field;
  }
}
