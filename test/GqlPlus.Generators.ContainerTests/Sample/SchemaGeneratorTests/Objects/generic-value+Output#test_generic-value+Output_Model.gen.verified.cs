//HintName: test_generic-value+Output_Model.gen.cs
// Generated from {CurrentDirectory}generic-value+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Output;

public class testGnrcValueOutp
  : GqlpModelImplementationBase
  , ItestGnrcValueOutp
{
  public ItestRefGnrcValueOutp<testEnumGnrcValueOutp>? AsEnumGnrcValueOutpgnrcValueOutp { get; set; }
  public ItestGnrcValueOutpObject? As_GnrcValueOutp { get; set; }
}

public class testGnrcValueOutpObject
  : GqlpModelImplementationBase
  , ItestGnrcValueOutpObject
{
}

public class testRefGnrcValueOutp<TType>
  : GqlpModelImplementationBase
  , ItestRefGnrcValueOutp<TType>
{
  public ItestRefGnrcValueOutpObject<TType>? As_RefGnrcValueOutp { get; set; }
}

public class testRefGnrcValueOutpObject<TType>
  : GqlpModelImplementationBase
  , ItestRefGnrcValueOutpObject<TType>
{
  public TType Field { get; set; }

  public testRefGnrcValueOutpObject
    ( TType field
    )
  {
    Field = field;
  }
}
