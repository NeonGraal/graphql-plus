﻿//HintName: Model_alt-mod-Boolean+input.gen.cs
// Generated from alt-mod-Boolean+input.graphql+

/*
*/

namespace GqlTest.Model_alt_mod_Boolean_input;

public interface IInpAltModBool
{
  AltInpAltModBool AsAltInpAltModBool { get; }
}
public class InputInpAltModBool
  : IInpAltModBool
{
  public AltInpAltModBool AsAltInpAltModBool { get; set; }
}

public interface IAltInpAltModBool
{
  Number alt { get; }
  String AsString { get; }
}
public class InputAltInpAltModBool
  : IAltInpAltModBool
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
