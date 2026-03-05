//HintName: test_constraint-alt+Output_Model.gen.cs
// Generated from {CurrentDirectory}constraint-alt+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_Output;

public class testCnstAltOutp<TType>
  : GqlpModelImplementationBase
  , ItestCnstAltOutp<TType>
{
  public TType? Astype { get; set; }
  public ItestCnstAltOutpObject<TType>? As_CnstAltOutp { get; set; }
}

public class testCnstAltOutpObject<TType>
  : GqlpModelImplementationBase
  , ItestCnstAltOutpObject<TType>
{

  public testCnstAltOutpObject
    ()
  {
  }
}
