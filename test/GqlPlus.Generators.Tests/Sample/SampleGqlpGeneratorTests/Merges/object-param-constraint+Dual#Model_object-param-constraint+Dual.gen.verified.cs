//HintName: Model_object-param-constraint+Dual.gen.cs
// Generated from object-param-constraint+Dual.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_object_param_constraint_Dual;

public interface IObjParamCnstDual<Ttest>
{
  Ttest test { get; }
  Ttest type { get; }
}
public class DualObjParamCnstDual<Ttest>
  : IObjParamCnstDual<Ttest>
{
  public Ttest test { get; set; }
  public Ttest type { get; set; }
}
