//HintName: test_generic-parent-simple-enum+Input_Model.gen.cs
// Generated from {CurrentDirectory}generic-parent-simple-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_simple_enum_Input;

public class testGnrcPrntSmplEnumInp
  : testFieldGnrcPrntSmplEnumInp<testEnumGnrcPrntSmplEnumInp>
  , ItestGnrcPrntSmplEnumInp
{
  public ItestGnrcPrntSmplEnumInpObject? As_GnrcPrntSmplEnumInp { get; set; }
}

public class testGnrcPrntSmplEnumInpObject
  : testFieldGnrcPrntSmplEnumInpObject<testEnumGnrcPrntSmplEnumInp>
  , ItestGnrcPrntSmplEnumInpObject
{

  public testGnrcPrntSmplEnumInpObject
    ( testEnumGnrcPrntSmplEnumInp field
    ) : base(field)
  {
  }
}

public class testFieldGnrcPrntSmplEnumInp<TRef>
  : GqlpModelImplementationBase
  , ItestFieldGnrcPrntSmplEnumInp<TRef>
{
  public ItestFieldGnrcPrntSmplEnumInpObject<TRef>? As_FieldGnrcPrntSmplEnumInp { get; set; }
}

public class testFieldGnrcPrntSmplEnumInpObject<TRef>
  : GqlpModelImplementationBase
  , ItestFieldGnrcPrntSmplEnumInpObject<TRef>
{
  public TRef Field { get; set; }

  public testFieldGnrcPrntSmplEnumInpObject
    ( TRef field
    )
  {
    Field = field;
  }
}
