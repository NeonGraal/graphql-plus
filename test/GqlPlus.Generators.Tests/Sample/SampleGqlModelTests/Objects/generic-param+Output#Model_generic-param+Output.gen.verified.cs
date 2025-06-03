//HintName: Model_generic-param+Output.gen.cs
// Generated from generic-param+Output.graphql+

/*
*/

namespace GqlTest.Model_generic_param_Output;

public interface IOutpGnrcParam
{
  OutpGnrcParamRef<OutpGnrcParamAlt> field { get; }
}
public class OutputOutpGnrcParam
  : IOutpGnrcParam
{
  public OutpGnrcParamRef<OutpGnrcParamAlt> field { get; set; }
}

public interface IOutpGnrcParamRef<Tref>
{
  Tref Asref { get; }
}
public class OutputOutpGnrcParamRef<Tref>
  : IOutpGnrcParamRef<Tref>
{
  public Tref Asref { get; set; }
}

public interface IOutpGnrcParamAlt
{
  Number alt { get; }
  String AsString { get; }
}
public class OutputOutpGnrcParamAlt
  : IOutpGnrcParamAlt
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
