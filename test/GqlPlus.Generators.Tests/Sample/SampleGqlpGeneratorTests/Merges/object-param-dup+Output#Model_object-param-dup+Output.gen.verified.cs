//HintName: Model_object-param-dup+Output.gen.cs
// Generated from object-param-dup+Output.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_object_param_dup_Output;

public interface IObjParamDupOutp<Ttest>
{
  Ttest test { get; }
  Ttest type { get; }
}
public class OutputObjParamDupOutp<Ttest>
  : IObjParamDupOutp<Ttest>
{
  public Ttest test { get; set; }
  public Ttest type { get; set; }
}
