//HintName: Model_object-param+dual.gen.cs
// Generated from object-param+dual.graphql+

/*
*/

namespace GqlTest.Model_object_param_dual;

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
