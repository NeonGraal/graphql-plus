//HintName: Model_generic-field-dual+Dual.gen.cs
// Generated from generic-field-dual+Dual.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_generic_field_dual_Dual;

public interface IGnrcFieldDualDual
{
  RefGnrcFieldDualDual<AltGnrcFieldDualDual> field { get; }
}
public class DualGnrcFieldDualDual
  : IGnrcFieldDualDual
{
  public RefGnrcFieldDualDual<AltGnrcFieldDualDual> field { get; set; }
}

public interface IRefGnrcFieldDualDual<Tref>
{
  Tref Asref { get; }
}
public class DualRefGnrcFieldDualDual<Tref>
  : IRefGnrcFieldDualDual<Tref>
{
  public Tref Asref { get; set; }
}

public interface IAltGnrcFieldDualDual
{
  Number alt { get; }
  String AsString { get; }
}
public class DualAltGnrcFieldDualDual
  : IAltGnrcFieldDualDual
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
