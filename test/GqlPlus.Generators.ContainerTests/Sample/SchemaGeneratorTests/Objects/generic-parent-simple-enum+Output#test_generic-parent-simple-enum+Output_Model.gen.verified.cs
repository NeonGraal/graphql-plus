//HintName: test_generic-parent-simple-enum+Output_Model.gen.cs
// Generated from {CurrentDirectory}generic-parent-simple-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
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

  public testGnrcPrntSmplEnumOutpObject
    ( testEnumGnrcPrntSmplEnumOutp pfield
    ) : base(pfield)
  {
  }
}

public class testFieldGnrcPrntSmplEnumOutp<TRef>
  : GqlpModelBase
  , ItestFieldGnrcPrntSmplEnumOutp<TRef>
{
  public ItestFieldGnrcPrntSmplEnumOutpObject<TRef>? As_FieldGnrcPrntSmplEnumOutp { get; set; }
}

public class testFieldGnrcPrntSmplEnumOutpObject<TRef>
  : GqlpModelBase
  , ItestFieldGnrcPrntSmplEnumOutpObject<TRef>
{
  public TRef Field { get; set; }

  public testFieldGnrcPrntSmplEnumOutpObject
    ( TRef pfield
    )
  {
    Field = pfield;
  }
}
