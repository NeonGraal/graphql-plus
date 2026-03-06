//HintName: test_generic-enum+Output_Model.gen.cs
// Generated from {CurrentDirectory}generic-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Output;

public class testGnrcEnumOutp
  : GqlpModelImplementationBase
  , ItestGnrcEnumOutp
{
  public ItestRefGnrcEnumOutp<testEnumGnrcEnumOutp>? AsEnumGnrcEnumOutpgnrcEnumOutp { get; set; }
  public ItestGnrcEnumOutpObject? As_GnrcEnumOutp { get; set; }
}

public class testGnrcEnumOutpObject
  : GqlpModelImplementationBase
  , ItestGnrcEnumOutpObject
{

  public testGnrcEnumOutpObject
    ()
  {
  }
}

public class testRefGnrcEnumOutp<TType>
  : GqlpModelImplementationBase
  , ItestRefGnrcEnumOutp<TType>
{
  public ItestRefGnrcEnumOutpObject<TType>? As_RefGnrcEnumOutp { get; set; }
}

public class testRefGnrcEnumOutpObject<TType>
  : GqlpModelImplementationBase
  , ItestRefGnrcEnumOutpObject<TType>
{
  public TType Field { get; set; }

  public testRefGnrcEnumOutpObject
    ( TType field
    )
  {
    Field = field;
  }
}
