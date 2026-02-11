//HintName: test_object-param+Output_Intf.gen.cs
// Generated from object-param+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_Output;

public interface ItestObjParamOutp<Ttest,Ttype>
{
  ItestObjParamOutpObject AsObjParamOutp { get; }
}

public interface ItestObjParamOutpObject<Ttest,Ttype>
{
  Ttest Test { get; }
  Ttype Type { get; }
}
