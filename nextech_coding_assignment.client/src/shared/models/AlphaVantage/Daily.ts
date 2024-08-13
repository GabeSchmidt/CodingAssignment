import { TimeInterval } from "./TimeInterval";

export interface Daily {
  metaData: DailyMetaData;
  intervals: Record<string, TimeInterval>;
}

export interface DailyMetaData {
  information: string;
  symbol: string;
  lastRefreshed: string;
  outputSize: string;
  timeZone: string;
}
