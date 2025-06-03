//HintName: Model_generic-field-dual+Dual.gen.cs
// Generated from generic-field-dual+Dual.graphql+

/*
*/

namespace GqlTest.Model_generic_field_dual_Dual;

public interface IDualGnrcFieldDual
{
  RefDualGnrcFieldDual<AltDualGnrcFieldDual> field { get; }
}
public class DualDualGnrcFieldDual
  : IDualGnrcFieldDual
{
  public RefDualGnrcFieldDual<AltDualGnrcFieldDual> field { get; set; }
}

public interface IRefDualGnrcFieldDual<Tref>
{
  Tref Asref { get; }
}
public class DualRefDualGnrcFieldDual<Tref>
  : IRefDualGnrcFieldDual<Tref>
{
  public Tref Asref { get; set; }
}

public interface IAltDualGnrcFieldDual
{
  Number alt { get; }
  String AsString { get; }
}
public class DualAltDualGnrcFieldDual
  : IAltDualGnrcFieldDual
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
