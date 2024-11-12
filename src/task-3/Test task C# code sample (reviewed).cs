﻿/* TODO 
 * The Single Responsibility principle is violated here, the View part includes business logic.
 * To improve this it would be great to use MVVM, MVP (or other patterns suitable for a specific Desktop technology), 
 * or at least to move the business logic to a separate class.
 */

/* TODO 
 * It would be better to isolate business logic into a separate class or even group of classes.
 * Besides this, now the code is not testable due to poor separation of responsibilities and lack of abstraction layer.
 * Please consider introducing an abstraction layer.
 */

/* TODO
 * Probably the strings entered by the user like txtSymbol.Text, txtDatapoints.Text, txtDirection.Text,
 * and others, could be validated (at least a basic check for empty strings).
 */

/* TODO
 * There appear to be too many comments; some are duplicated or may be unnecessary since the code is already clear from naming.
 * Simplifying these would improve readability.
 */
private void btnGetData_Click(object sender, EventArgs e)
{
    /* TODO
     * There is no reason to allocate empty string here. Wasting of memory.
     */
    // clear previous request data
    string sRequest = "";
    lstData.Items.Clear();

    /* TODO
     * Comparing combo box text directly with a hard-coded string might not be optimal, 
     * as the text itself could change even if the business value remains the same.
     * Using binding or relying on the combo box Value property could improve resilience here.
     */

    /* TODO
     * The code below is a good candidate for refactoring. 
     * The switch statement could be replaced with a dictionary of delegates or a factory of commands.
     * This would make the code more extensible and maintainable.
     */
    // format request string based upon user input
    if (cboHistoryType.Text.Equals("Tick Datapoints"))
    {
        /* TODO
         * Magic strings such as "HIX" and "HTX" lack clear meaning for the code reader.
         * Using constants or enumerations would improve readability and make maintenance easier.
         */
        // request in the format:
        // HTX,SYMBOL,NUMDATAPOINTS,DIRECTION,REQUESTID,DATAPOINTSPERSEND<CR><LF>
        sRequest = String.Format("HTX,{0},{1},{2},{3},{4}\r\n", txtSymbol.Text, txtDatapoints.Text, txtDirection.Text, txtRequestID.Text, txtDatapointsPerSend.Text);
    }
    else if (cboHistoryType.Text.Equals("Tick Days"))
    {
        // request in the format:
        // HTD,SYMBOL,NUMDAYS,MAXDATAPOINTS,BEGINFILTERTIME,ENDFILTERTIME,DIRECTION,REQUESTID,DATAPOINTSPERSEND<CR><LF>
        sRequest = String.Format("HTD,{0},{1},{2},{3},{4},{5},{6},{7}\r\n", txtSymbol.Text, txtDays.Text, txtDatapoints.Text, txtBeginFilterTime.Text, txtEndFilterTime.Text, txtDirection.Text, txtRequestID.Text, txtDatapointsPerSend.Text);
    }
    else if (cboHistoryType.Text.Equals("Tick Timeframe"))
    {
        // request in the format:
        // HTT,SYMBOL,BEGINDATE BEGINTIME,ENDDATE ENDTIME,MAXDATAPOINTS,BEGINFILTERTIME,ENDFILTERTIME,DIRECTION,REQUESTID,DATAPOINTSPERSEND<CR><LF>
        sRequest = String.Format("HTT,{0},{1},{2},{3},{4},{5},{6},{7},{8}\r\n", txtSymbol.Text, txtBeginDateTime.Text, txtEndDateTime.Text, txtDatapoints.Text, txtBeginFilterTime.Text, txtEndFilterTime.Text, txtDirection.Text, txtRequestID.Text, txtDatapointsPerSend.Text);
    }
    else if (cboHistoryType.Text.Equals("Interval Datapoints"))
    {
        /* TODO
         * Here and below this part repeats three times.
         * Consider extracting this logic to a separate method to avoid code duplication.
         */
        // validate interval type
        string sIntervalType = "s";
        if (rbVolume.Checked)
        {
            sIntervalType = "v";
        }
        else if (rbTick.Checked)
        {
            sIntervalType = "t";
        }

        // request in the format:
        // HIX,SYMBOL,INTERVAL,NUMDATAPOINTS,DIRECTION,REQUESTID,DATAPOINTSPERSEND,INTERVALTYPE<CR><LF>
        sRequest = String.Format("HIX,{0},{1},{2},{3},{4},{5},{6},{7}\r\n", txtSymbol.Text, txtInterval.Text, txtDatapoints.Text, txtDirection.Text, txtRequestID.Text, txtDatapointsPerSend.Text, sIntervalType, chkBoxTimeStamp.Checked ? 1 : 0);
    }
    else if (cboHistoryType.Text.Equals("Interval Days"))
    {
        // validate interval type
        string sIntervalType = "s";
        if (rbVolume.Checked)
        {
            sIntervalType = "v";
        }
        else if (rbTick.Checked)
        {
            sIntervalType = "t";
        }

        // request in the format:
        // HID,SYMBOL,INTERVAL,NUMDAYS,MAXDATAPOINTS,BEGINFILTERTIME,ENDFILTERTIME,DIRECTION,REQUESTID,DATAPOINTSPERSEND,INTERVALTYPE,TIMESTAMPLABEL<CR><LF>
        sRequest = String.Format("HID,{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}\r\n", txtSymbol.Text, txtInterval.Text, txtDays.Text, txtDatapoints.Text, txtBeginFilterTime.Text, txtEndFilterTime.Text, txtDirection.Text, txtRequestID.Text, txtDatapointsPerSend.Text, sIntervalType, chkBoxTimeStamp.Checked ? 1 : 0);
    }
    else if (cboHistoryType.Text.Equals("Interval Timeframe"))
    {
        // validate interval type
        string sIntervalType = "s";
        if (rbVolume.Checked)
        {
            sIntervalType = "v";
        }
        else if (rbTick.Checked)
        {
            sIntervalType = "t";
        }

        // request in the format:
        // HIT,SYMBOL,INTERVAL,BEGINDATE BEGINTIME,ENDDATE ENDTIME,MAXDATAPOINTS,BEGINFILTERTIME,ENDFILTERTIME,DIRECTION,REQUESTID,DATAPOINTSPERSEND,INTERVALTYPE,TIMESTAMPLABEL<CR><LF>
        sRequest = String.Format("HIT,{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}\r\n", txtSymbol.Text, txtInterval.Text, txtBeginDateTime.Text, txtEndDateTime.Text, txtDatapoints.Text, txtBeginFilterTime.Text, txtEndFilterTime.Text, txtDirection.Text, txtRequestID.Text, txtDatapointsPerSend.Text, sIntervalType, chkBoxTimeStamp.Checked ? 1 : 0);
    }
    else if (cboHistoryType.Text.Equals("Daily Datapoints"))
    {
        // request in the format:
        // HDX,SYMBOL,NUMDATAPOINTS,DIRECTION,REQUESTID,DATAPOINTSPERSEND<CR><LF>
        sRequest = String.Format("HDX,{0},{1},{2},{3},{4},{5}\r\n", txtSymbol.Text, txtDatapoints.Text, txtDirection.Text, txtRequestID.Text, txtDatapointsPerSend.Text, chbAppendTick.Checked ? 1 : 0);
    }
    else if (cboHistoryType.Text.Equals("Daily Timeframe"))
    {
        // request in the format:
        // HDT,SYMBOL,BEGINDATE,ENDDATE,MAXDATAPOINTS,DIRECTION,REQUESTID,DATAPOINTSPERSEND<CR><LF>
        sRequest = String.Format("HDT,{0},{1},{2},{3},{4},{5},{6},{7}\r\n", txtSymbol.Text, txtBeginDateTime.Text, txtEndDateTime.Text, txtDatapoints.Text, txtDirection.Text, txtRequestID.Text, txtDatapointsPerSend.Text, chbAppendTick.Checked ? 1 : 0);
    }
    else if (cboHistoryType.Text.Equals("Weekly Datapoints"))
    {
        // request in the format:
        // HWX,SYMBOL,NUMDATAPOINTS,DIRECTION,REQUESTID,DATAPOINTSPERSEND<CR><LF>
        sRequest = String.Format("HWX,{0},{1},{2},{3},{4},{5}\r\n", txtSymbol.Text, txtDatapoints.Text, txtDirection.Text, txtRequestID.Text, txtDatapointsPerSend.Text, chbAppendTick.Checked ? 1 : 0);
    }
    else if (cboHistoryType.Text.Equals("Monthly Datapoints"))
    {
        // request in the format:
        // HMX,SYMBOL,NUMDATAPOINTS,DIRECTION,REQUESTID,DATAPOINTSPERSEND<CR><LF>
        sRequest = String.Format("HMX,{0},{1},{2},{3},{4},{5}\r\n", txtSymbol.Text, txtDatapoints.Text, txtDirection.Text, txtRequestID.Text, txtDatapointsPerSend.Text, chbAppendTick.Checked ? 1 : 0);
    }
    else
    {
        /* TODO
         * Assigning the error message to sRequest may reduce clarity and purpose.
         * Instead, we could keep sRequest empty and use a separate variable specifically for error messages,
         * making the code more readable and better organized.
         * As a consequence, we will also simplify the comparison line (sRequest.StartsWith("H")) below.
         * Also you can wrap this to response
         */
        // something unexpected happened
        sRequest = "Error Processing Request.";
    }

    // verify we have formed a request string
    if (sRequest.StartsWith("H"))
    {
        /* TODO
         * The request formation and sending are combined into a single method,
         * which affects the method's clarity and purpose.
         * Separating these concerns could help adhere to the Single Responsibility Principle.
         */
        // send it to the feed via the socket
        SendRequestToIQFeed(sRequest);
    }
    else
    {
        string sError = String.Format("{0}\r\nRequest type selected was: {1}", sRequest, cboHistoryType.Text);
        UpdateListview(sError);
    }

    /* TODO
     * Naming issue.
     * If the naming reflected the essence, there would be no need for a comment.
     * In addition, the passing of magic line.
     */
    // tell the socket we are ready to receive data
    WaitForData("History");
    /* TODO
     * Formatting issue. The code is not aligned properly.
     */
    }
