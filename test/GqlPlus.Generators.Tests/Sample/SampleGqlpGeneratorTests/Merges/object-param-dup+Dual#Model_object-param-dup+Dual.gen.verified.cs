//HintName: Model_object-param-dup+Dual.gen.cs
// Generated from object-param-dup+Dual.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_object_param_dup_Dual;

public interface IObjParamDupDual<Ttest>
{
  Ttest test { get; }
  Ttest type { get; }
}
public class DualObjParamDupDual<Ttest>
  : IObjParamDupDual<Ttest>
{
  public Ttest test { get; set; }
  public Ttest type { get; set; }
}
