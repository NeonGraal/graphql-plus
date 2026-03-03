//HintName: test_generic-parent-enum-child+Output_Impl.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-child+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_child_Output;

public class testGnrcPrntEnumChildOutp
  : testFieldGnrcPrntEnumChildOutp<testParentGnrcPrntEnumChildOutp>
  , ItestGnrcPrntEnumChildOutp
{
  public ItestGnrcPrntEnumChildOutpObject? As_GnrcPrntEnumChildOutp { get; set; }
}

public class testGnrcPrntEnumChildOutpObject
  : testFieldGnrcPrntEnumChildOutpObject<testParentGnrcPrntEnumChildOutp>
  , ItestGnrcPrntEnumChildOutpObject
{

  public testGnrcPrntEnumChildOutpObject
    ( testParentGnrcPrntEnumChildOutp field
    ) : base(field)
  {
  }
}

public class testFieldGnrcPrntEnumChildOutp<TRef>
  : GqlpModelImplementationBase
  , ItestFieldGnrcPrntEnumChildOutp<TRef>
{
  public ItestFieldGnrcPrntEnumChildOutpObject<TRef>? As_FieldGnrcPrntEnumChildOutp { get; set; }
}

public class testFieldGnrcPrntEnumChildOutpObject<TRef>
  : GqlpModelImplementationBase
  , ItestFieldGnrcPrntEnumChildOutpObject<TRef>
{
  public TRef Field { get; set; }

  public testFieldGnrcPrntEnumChildOutpObject
    ( TRef field
    )
  {
    Field = field;
  }
}
