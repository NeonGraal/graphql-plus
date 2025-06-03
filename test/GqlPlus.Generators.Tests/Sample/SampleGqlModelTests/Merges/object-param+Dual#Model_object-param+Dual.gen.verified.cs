//HintName: Model_object-param+Dual.gen.cs
// Generated from object-param+Dual.graphql+

/*
*/

namespace GqlTest.Model_object_param_Dual;

public interface IDualObjParam<Ttest,Ttype>
{
  Ttest test { get; }
  Ttype type { get; }
}
public class DualDualObjParam<Ttest,Ttype>
  : IDualObjParam<Ttest,Ttype>
{
  public Ttest test { get; set; }
  public Ttype type { get; set; }
}
