//HintName: Model_object-param-constraint+Output.gen.cs
// Generated from object-param-constraint+Output.graphql+

/*
*/

namespace GqlTest.Model_object_param_constraint_Output;

public interface IObjParamCnstOutp<Ttest>
{
  Ttest test { get; }
  Ttest type { get; }
}
public class OutputObjParamCnstOutp<Ttest>
  : IObjParamCnstOutp<Ttest>
{
  public Ttest test { get; set; }
  public Ttest type { get; set; }
}
