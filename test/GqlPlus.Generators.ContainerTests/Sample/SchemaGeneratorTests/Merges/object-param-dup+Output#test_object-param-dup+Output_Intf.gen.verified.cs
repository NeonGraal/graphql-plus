//HintName: test_object-param-dup+Output_Intf.gen.cs
// Generated from object-param-dup+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_param_dup_Output;

public interface ItestObjParamDupOutp<Ttest>
{
  ItestObjParamDupOutpObject AsObjParamDupOutp { get; }
}

public interface ItestObjParamDupOutpObject<Ttest>
{
  Ttest Test { get; }
  Ttest Type { get; }
}
